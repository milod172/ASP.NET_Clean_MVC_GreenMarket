using AutoMapper;
using GreenMarket.Application.Contacts.Persistence;
using GreenMarket.Application.Features.Categories.Dto;
using GreenMarket.Domain.Entities;
using MediatR;

namespace GreenMarket.Application.Features.Categories.Commands
{
    public class CreateCategoryHandler(IMapper _mapper, ICategoryRepository _categoryRepository) : IRequestHandler<CreateCategoryCommand, CreateCategoryDto>
    {
        public async Task<CreateCategoryDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryExist = await _categoryRepository.AnyAsync(x => x.CategoryName == request.CategoryName, cancellationToken);
            if (categoryExist) { throw new ArgumentException($"Tên danhh mục: '{request.CategoryName}' đã tồn tại trong hệ thống. Vui lòng kiểm tra lại"); }

            var category = Category.Create(request.CategoryName, request.Description, request.ParentCategoryId);
            
            await _categoryRepository.AddAsync(category, cancellationToken);
            return _mapper.Map<CreateCategoryDto>(category);
        }
    }
}
