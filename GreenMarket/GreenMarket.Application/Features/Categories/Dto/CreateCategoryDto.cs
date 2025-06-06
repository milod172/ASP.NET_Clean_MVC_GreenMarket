using AutoMapper;
using GreenMarket.Application.Common.Mappers;
using GreenMarket.Domain.Entities;

namespace GreenMarket.Application.Features.Categories.Dto
{
    public class CreateCategoryDto : IMapFrom<Category>
    {
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CreateCategoryDto>();
        }
    }
}
