using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
namespace GreenMarket.API.Configurations
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection services, JwtSettings jwtSettings)
        {
            services.AddHttpContextAccessor();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,

                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,

                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),

                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
      
            return services;
        }
    }
}

