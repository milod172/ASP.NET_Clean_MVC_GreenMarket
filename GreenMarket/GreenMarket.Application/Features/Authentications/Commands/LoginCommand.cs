using GreenMarket.Application.Common.Interfaces;
using GreenMarket.Application.Features.Authentications.Dto;
using MediatR;

namespace GreenMarket.Application.Features.Authentications.Commands
{
    public class LoginCommand : IRequest<LoginDto>, ICommand
    {
        public string Gmail { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
