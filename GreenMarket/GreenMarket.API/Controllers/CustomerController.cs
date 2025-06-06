using GreenMarket.API.Configurations;
using GreenMarket.Application.Common.Pagination;
using GreenMarket.Application.Features.Products.Dto;
using GreenMarket.Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class CustomerController(IMediator mediator) : ControllerBase
    {
        
    }
}
