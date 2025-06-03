using AutoMapper;
using GreenMarket.Application.Common.Mappers;
using GreenMarket.Domain.Entities;

namespace GreenMarket.Application.Features.Products.Dto
{
    public class GetProductDetailsDto : IMapFrom<Product>
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal? UnitPrice { get; set; }
        public string? Details { get; set; } = string.Empty;
        public int TotalQuantity { get; set; } = 0;
        public string Sku { get; set; } = string.Empty;
        public int TotalSell { get; set; } = 0;
        public int? CategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, GetProductDetailsDto>();
        }
    }
}
