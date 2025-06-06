using GreenMarket.Application.Common.Interfaces;
using GreenMarket.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GreenMarket.API.Configurations
{
    public class JwtService(JwtSettings _jwtSettings) : IJwtService
    {
        public string GenerateJwtToken(ApplicationUser user, IList<string> roles)
        {
            var claims = new List<Claim>
            {
                new(JwtRegisteredClaimNames.Sub, user.Id),       
            };

            foreach (var role in roles)
                claims.Add(new(ClaimTypes.Role, role));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);        
            var token = new JwtSecurityToken(
               _jwtSettings.Issuer,
               _jwtSettings.Audience,
               claims: claims,
               expires: DateTime.Now.AddDays(1),
               signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
