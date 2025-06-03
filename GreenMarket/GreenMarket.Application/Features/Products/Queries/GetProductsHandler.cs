using AutoMapper;
using GreenMarket.Application.Common.Pagination;
using GreenMarket.Application.Contacts.Persistence;
using GreenMarket.Application.Features.Products.Dto;
using MediatR;

namespace GreenMarket.Application.Features.Products.Queries
{
    public class GetProductsHandler(IMapper _mapper ,IProductRepository _productRepository) : IRequestHandler<GetProductsQuery, PaginationList<GetProductDetailsDto>>
    {
        public async Task<PaginationList<GetProductDetailsDto>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var products =  await _productRepository.GetPaginated(request,
                null,   //p => p.Sku == "OT-BOT"
                null,   //query => query.Include(p => p.Category)
                cancellationToken);

            var dto = _mapper.Map<List<GetProductDetailsDto>>(products.Items);

            var pagedResult = new PaginationList<GetProductDetailsDto>(
                dto,
                products.TotalCount,
                products.PageNumber,
                products.PageSize
                );

            return pagedResult;
        }
    }
}
