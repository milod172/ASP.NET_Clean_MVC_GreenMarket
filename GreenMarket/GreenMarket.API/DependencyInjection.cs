using System.Reflection;
using FluentValidation;
using GreenMarket.Application.Common.Interfaces;

namespace GreenMarket.API.Configurations
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Add Controllers & API Behavior
            services.AddControllers();

            //Add API Versioning
            services.ConfigureApiVersioning();

            //Config API Versioning 
            services.ConfigureOptions<ApiVersionSwaggerGenOptions>();

            //Config Swagger (auth, description, filter,...)
            services.ConfigureSwashbuckle();

            services.AddSingleton<IJwtService, JwtService>();
            return services;
        } 
    }
}
