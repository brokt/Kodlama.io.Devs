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
            });

        }
    }
}
