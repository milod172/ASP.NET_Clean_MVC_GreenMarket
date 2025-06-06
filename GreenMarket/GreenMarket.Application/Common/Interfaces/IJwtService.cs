using System.Security.Claims;
using System.Text;
using GreenMarket.Domain.Entities;

namespace GreenMarket.Application.Common.Interfaces
{
    public interface IJwtService
    {
        string GenerateJwtToken(ApplicationUser user, IList<string> roles);
    }

}
