using Core.Security.Entities;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public class KodlamaioDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgramingLangues> ProgramingLangues { get; set; }
        public DbSet<ProgramingTechnologies> ProgramingTechnologies { get; set; }
        public DbSet<UserSocialMedias> UserSocialMedias { get; set; }
        public DbSet<CodeSocialMediaTypes> CodeSocialMediaTypes { get; set; }

        #region Core Securitory
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        #endregion

        public KodlamaioDbContext(DbContextOptions options,IConfiguration configuration) :base(options)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgramingLangues>(a =>
            {
                a.ToTable("ProgramingLangues").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");

                a.HasMany(p => p.ProgramingTechnologies);
            }); 
            
            modelBuilder.Entity<ProgramingTechnologies>(a =>
            {
                a.ToTable("ProgramingTechnologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name").HasMaxLength(60);
                a.Property(p => p.ProgramingLanguesId).HasColumnName("ProgramingLanguesId");

                a.HasOne(p => p.ProgramingLangues);
            }); 
            
            modelBuilder.Entity<UserSocialMedias>(a =>
            {
                a.ToTable("UserSocialMedias").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Link).HasColumnName("Link").HasMaxLength(180);
                a.Property(p => p.CodeSocialMediaTypesId).HasColumnName("CodeSocialMediaTypesId");

                a.HasOne(p => p.User);
                a.HasOne(p => p.CodeSocialMediaTypes);
            }); 
            
            modelBuilder.Entity<CodeSocialMediaTypes>(a =>
            {
                a.ToTable("CodeSocialMediaTypes").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name").HasMaxLength(180);
                a.Property(p => p.InUse).HasColumnName("InUse");
                a.Property(p => p.Order).HasColumnName("Order");

                a.HasMany(p => p.UserSocialMedias);
            });

            #region Core Security

            modelBuilder.Entity<User>(p =>
            {
                p.ToTable("Users").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.FirstName).HasColumnName("FirstName");
                p.Property(p => p.LastName).HasColumnName("LastName");
                p.Property(p => p.Email).HasColumnName("Email");
                p.Property(p => p.PasswordSalt).HasColumnName("PasswordSalt");
                p.Property(p => p.PasswordHash).HasColumnName("PasswordHash");
                p.Property(p => p.Status).HasColumnName("Status");
                p.Property(p => p.AuthenticatorType).HasColumnName("AuthenticatorType");

                p.HasMany(p => p.UserOperationClaims);
                p.HasMany(p => p.RefreshTokens);
            });

            modelBuilder.Entity<OperationClaim>(p =>
            {
                p.ToTable("OperationClaims").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.Name).HasColumnName("Name");
            });

            modelBuilder.Entity<UserOperationClaim>(p =>
            {
                p.ToTable("UserOperationClaims").HasKey(k => k.Id);
                p.Property(p => p.Id).HasColumnName("Id");
                p.Property(p => p.UserId).HasColumnName("UserId");
                p.Property(p => p.OperationClaimId).HasColumnName("OperationClaimId");

                p.HasOne(p => p.User);
                p.HasOne(p => p.OperationClaim);
            });
            #endregion


            ProgramingLangues[] programmingLanguageEntitySeeds = { new(1, "C#"), new(2, "Java") };
            modelBuilder.Entity<ProgramingLangues>().HasData(programmingLanguageEntitySeeds);

            ProgramingTechnologies[] technologyEntitySeeds = { new(1, "ASP.NET",1), new(2, "WPF",1),
                new(3, "Spring", 2), new(4, "JSP", 2) };
            modelBuilder.Entity<ProgramingTechnologies>().HasData(technologyEntitySeeds);

            OperationClaim[] operationClaimSeeds = { new(1, "Admin"), new(2, "User") };
            modelBuilder.Entity<OperationClaim>().HasData(operationClaimSeeds);

            CodeSocialMediaTypes[] socialMediaTypes = { new(1, "Github",true,1), new(2, "Instagram", true, 1) };
            modelBuilder.Entity<CodeSocialMediaTypes>().HasData(socialMediaTypes);

        }
    }
}
