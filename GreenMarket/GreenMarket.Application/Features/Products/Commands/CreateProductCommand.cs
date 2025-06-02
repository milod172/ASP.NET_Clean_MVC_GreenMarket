using AutoMapper;
using GreenMarket.Application.Common.Interfaces;
using GreenMarket.Application.Common.Mappers;
using GreenMarket.Application.Features.Products.Dto;
using GreenMarket.Domain.Entities;
using MediatR;

namespace GreenMarket.Application.Features.Products.Commands
{
    public class CreateProductCommand : IRequest<CreateProductDto>, IMapFrom<Product>, ICommand
    {
        public string ProductName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public string? Details { get; set; }
        public int? CategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateProductCommand, Product>();
        }
    }
}
