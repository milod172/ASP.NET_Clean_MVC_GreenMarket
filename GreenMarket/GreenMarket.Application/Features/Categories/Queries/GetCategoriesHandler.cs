using AutoMapper;
using GreenMarket.Application.Common.Pagination;
using GreenMarket.Application.Contacts.Persistence;
using GreenMarket.Application.Features.Categories.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace GreenMarket.Application.Features.Categories.Queries
{
    public class GetCategoriesHandler(IMapper _mapper, ICategoryRepository _categoryRepository) : IRequestHandler<GetCategoriesQuery, PaginationList<GetCategoryDto>>
    {
        public async Task<PaginationList<GetCategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetPaginated(request,
                 null,
                 query => query.Include(x => x.SubCategories),
                 cancellationToken
            );

            var dto = categories.Items.Count > 0
                        ? _mapper.Map<List<GetCategoryDto>>(categories.Items)
                        : [];

            var pagedResult = new PaginationList<GetCategoryDto>(
                dto,
                categories?.TotalCount ?? 0,
                categories?.PageNumber ?? request.PageNumber,
                categories?.PageSize ?? request.PageSize
                );

            return pagedResult;
        }
    }
}
