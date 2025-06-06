using AutoMapper;
using GreenMarket.Application.Common.Mappers;
using GreenMarket.Domain.Entities;

namespace GreenMarket.Application.Features.Categories.Dto
{
    public class GetSubCategoryDto : IMapFrom<Category>
    {
        public int Id {  get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; }
        public string ParentCategoryName { get; set;} = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, GetSubCategoryDto>()
                .ForMember(dest => dest.ParentCategoryName, opt => opt.MapFrom(x => x.ParentCategory!.CategoryName));
        }
    }
}
