using Application.Features.ProgramingLangue.Rules;
using Application.Features.ProgramingTechnology.Rules;
using Application.Features.Users.Rules;
using Application.Features.UserSocialMedia.Rules;
using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using FluentValidation;
using Mapster;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddScoped<ProgramingLangueBusinessRules>();
            services.AddScoped<ProgramingTechnologyBusinessRules>();
            services.AddScoped<UserSocialMediaBusinessRules>();
            services.AddScoped<UserBusinessRules>();
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            var typeAdapterConfig = TypeAdapterConfig.GlobalSettings;
            // scans the assembly and gets the IRegister, adding the registration to the TypeAdapterConfig
            typeAdapterConfig.Scan(Assembly.GetExecutingAssembly());
            // register the mapper as Singleton service for my application
            var mapperConfig = new Mapper(typeAdapterConfig);
            services.AddSingleton<IMapper>(mapperConfig);

            Func<IServiceProvider, ClaimsPrincipal> getPrincipal = (sp) =>
               sp.GetService<IHttpContextAccessor>().HttpContext?.User ??
               new ClaimsPrincipal(new ClaimsIdentity("Unknown"));

            services.AddScoped<IPrincipal>(getPrincipal);

            return services;

        }
    }
}