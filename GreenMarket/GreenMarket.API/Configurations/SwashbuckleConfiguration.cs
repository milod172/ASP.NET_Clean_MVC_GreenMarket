using Microsoft.OpenApi.Models;

namespace GreenMarket.API.Configurations
{
    public static class SwashbuckleConfiguration
    {
        public static IServiceCollection ConfigureSwashbuckle(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer(); //Swagger found endpoint api
            services.AddSwaggerGen(options =>
            {              
                var securityScheme = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer {token}' (without quotes).",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                };

                // Define the Bearer token security scheme for Swagger (JWT Authorization header)
                options.AddSecurityDefinition("Bearer", securityScheme);

                // Apply the Bearer security scheme globally to all API endpoints
                options.AddSecurityRequirement(
                    new OpenApiSecurityRequirement
                    {
                        { securityScheme, Array.Empty<string>() }
                    }
                );
            });

            return services;
        }
    }
}
