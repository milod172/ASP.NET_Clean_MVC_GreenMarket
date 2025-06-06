using GreenMarket.Application.Common.Interfaces;
using GreenMarket.Application.Features.Authentications.Dto;
using GreenMarket.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace GreenMarket.Application.Features.Authentications.Commands
{
    public class LoginHandler(UserManager<ApplicationUser> _userManager, IJwtService _jwtService): IRequestHandler<LoginCommand, LoginDto>
    {
        public async Task<LoginDto> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByEmailAsync(command.Gmail);

            if (user == null || !await _userManager.CheckPasswordAsync(user, command.Password)) {
                throw new UnauthorizedAccessException("Tên đăng nhập hoặc mật khẩu không đúng.");
            }

            var roles = await _userManager.GetRolesAsync(user);

            var token =  _jwtService.GenerateJwtToken(user, roles);

            return new LoginDto {
                Token = token,
            };

        }
    }
}
