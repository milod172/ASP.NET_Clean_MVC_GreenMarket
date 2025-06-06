using GreenMarket.Application.Common.Pagination;
using GreenMarket.Application.Features.Categories.Dto;
using MediatR;

namespace GreenMarket.Application.Features.Categories.Queries
{
    public class GetCategoriesQuery() : PaginatedQuery, IRequest<PaginationList<GetCategoryDto>>
    {
    }
}
