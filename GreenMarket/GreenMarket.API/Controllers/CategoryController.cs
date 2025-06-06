using GreenMarket.API.Configurations;
using GreenMarket.API.Constants;
using GreenMarket.Application.Common.Pagination;
using GreenMarket.Application.Features.Categories.Commands;
using GreenMarket.Application.Features.Categories.Dto;
using GreenMarket.Application.Features.Categories.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GreenMarket.API.Controllers
{
    [Route("api/v{version:apiVersion}")]
    [ApiController]
    public class CategoryController(IMediator mediator) : ControllerBase
    {
        [HttpGet("categories")]
        public async Task<ActionResult<PaginationList<GetCategoryDto>>> GetProducts([FromQuery] GetCategoriesQuery query, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(query, cancellationToken);
            return Ok(new JsonResponse<PaginationList<GetCategoryDto>>(result));
        }

        [Authorize(Roles = ApplicationRole.Admin)]
        [HttpPost("category")]
        public async Task<ActionResult<CreateCategoryDto>> AddCategory([FromBody] CreateCategoryCommand command, CancellationToken cancellationToken)
        {
            var result = await mediator.Send(command, cancellationToken);
            return CreatedAtAction(nameof(AddCategory), new JsonResponse<CreateCategoryDto>(result));
        }
    }
}
