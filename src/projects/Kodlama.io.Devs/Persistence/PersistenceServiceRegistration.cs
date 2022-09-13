using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Contexts;
using Persistence.Repositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            services.AddDbContext<KodlamaioDbContext>(options =>
                                                     options.UseSqlServer(
                                                         configuration.GetConnectionString("KodlamaioConnectionString")));
            services.AddScoped<IProgramingLanguesRepository, ProgramingLanguesRepository>();
            services.AddScoped<IProgramingTechnologiesRepository, ProgramingTechnologiesRepository>();
            services.AddScoped<IUserSocialMediasRepository, UserSocialMediasRepository>();

            #region Core Security
            services.AddScoped<IUsersRepository, UsersRepository>();
            services.AddScoped<IOperationClaimsRepository, OperationClaimsRepository>();
            services.AddScoped<IUserOperationClaimsRepository, UserOperationClaimsRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            #endregion

            return services;
        }
    }
}