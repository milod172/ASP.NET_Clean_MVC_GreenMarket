using AutoMapper;
using GreenMarket.Application.Common.Mappers;
using GreenMarket.Domain.Entities;

namespace GreenMarket.Application.Features.Products.Dto
{
    public class CreateProductDto : IMapFrom<Product>
    {
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? UnitPrice { get; private set; }
        public string Details { get; private set; } = string.Empty;
        public string Sku { get; set; } = string.Empty;
        public int? CategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, CreateProductDto>();
        }
    }
}
