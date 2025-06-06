using GreenMarket.API.Configurations;
using GreenMarket.Application.Features.Authentications.Commands;
using GreenMarket.Application.Features.Authentications.Dto;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers
{
    [Route("api/v{version:apiVersion}/authentication")]
    [ApiController]
    public class AuthenticationController(IMediator mediator) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<LoginDto>> Login([FromBody] LoginCommand command)
        {          
            var result = await mediator.Send(command);
            return Ok(new JsonResponse<LoginDto>(result));  
        }
    }
}
