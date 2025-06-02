using AutoMapper;
using GreenMarket.Application.Contacts.Persistence;
using GreenMarket.Application.Features.Products.Dto;
using GreenMarket.Domain.Entities;
using MediatR;

namespace GreenMarket.Application.Features.Products.Commands
{
    public class CreateProductHandler(IMapper _mapper, IProductRepository _productRepository) : IRequestHandler<CreateProductCommand, CreateProductDto>
    {
        public async Task<CreateProductDto> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var productExist = await _productRepository.AnyAsync(x => x.ProductName == request.ProductName, cancellationToken);
            if(productExist) { throw new ArgumentException($"Tên sản phẩm: '{request.ProductName}' đã tồn tại trong hệ thống. Vui lòng kiểm tra lại"); }

            var product = Product.Create(request.ProductName, request.Description, request.UnitPrice, request.CategoryId, request.Details);

            await _productRepository.AddAsync(product, cancellationToken);

            return _mapper.Map<CreateProductDto>(product);
        }
    }
}
