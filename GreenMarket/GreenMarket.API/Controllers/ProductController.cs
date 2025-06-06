using GreenMarket.API.Configurations;
using GreenMarket.API.Constants;
using GreenMarket.Application.Common.Pagination;
using GreenMarket.Application.Features.Products.Commands;
using GreenMarket.Application.Features.Products.Dto;
using GreenMarket.Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {  
        [HttpGet("products")]
        public async Task<ActionResult<PaginationList<GetProductDetailsDto>>> GetProducts([FromQuery] GetProductsQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<PaginationList<GetProductDetailsDto>>(result));
        }

        [Authorize(Roles = ApplicationRole.Admin)]
        [HttpPost("product")]
        public async Task<ActionResult<CreateProductDto>> AddProduct([FromBody] CreateProductCommand command, CancellationToken cancellationToken)
        {       
            var result = await mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(AddProduct), new JsonResponse<CreateProductDto>(result));   
        }
    }
}
