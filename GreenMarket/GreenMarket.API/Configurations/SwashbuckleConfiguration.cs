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
                // Define the Bearer authentication scheme
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Enter 'Bearer {token}' (without quotes).",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT"
                });

                // Add a global security requirement using the Bearer scheme
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer" // Must match the name defined in AddSecurityDefinition
                            },
                            Scheme = "bearer",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>() // No scopes needed for JWT Bearer
                    }
                });
            });

            return services;
        }
    }
}
