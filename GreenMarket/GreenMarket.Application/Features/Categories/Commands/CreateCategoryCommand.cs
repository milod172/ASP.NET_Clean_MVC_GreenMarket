using AutoMapper;
using GreenMarket.Application.Common.Interfaces;
using GreenMarket.Application.Common.Mappers;
using GreenMarket.Application.Features.Categories.Dto;
using GreenMarket.Domain.Entities;
using MediatR;

namespace GreenMarket.Application.Features.Categories.Commands
{
    public class CreateCategoryCommand : IRequest<CreateCategoryDto>, IMapFrom<Category>, ICommand
    {
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCategoryCommand, Category>();
        }
    }
}
