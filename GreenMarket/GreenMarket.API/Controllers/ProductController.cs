using GreenMarket.Application.Common.Pagination;
using GreenMarket.Application.Features.Products.Commands;
using GreenMarket.Application.Features.Products.Dto;
using GreenMarket.Application.Features.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers
{
    [Route("api/v{version:apiVersion}/products")]
    [ApiController]
    public class ProductController(IMediator mediator) : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<PaginationList<GetProductDetailsDto>>> GetProducts([FromQuery] GetProductsQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<CreateProductDto>> AddProduct([FromBody] CreateProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var result = await mediator.Send(command, cancellationToken);
                return CreatedAtAction(nameof(AddProduct), result);
            }
            catch (FluentValidation.ValidationException ex)
            {
                return BadRequest(new { Errors = ex.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }) });
            }
            
        }
    }
}
