using GreenMarket.Application.Common.Pagination;
using GreenMarket.Application.Features.Products.Dto;
using MediatR;

namespace GreenMarket.Application.Features.Products.Queries
{
    public class GetProductsQuery() : PaginatedQuery, IRequest<PaginationList<GetProductDetailsDto>>
    {
    }
}
