using AutoMapper;
using GreenMarket.Application.Common.Mappers;
using GreenMarket.Domain.Entities;

namespace GreenMarket.Application.Features.Categories.Dto
{
    public class GetCategoryDto : IMapFrom<Category>
    {
        public int Id {  get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public int? ParentCategoryId { get; set; }
        public ICollection<GetSubCategoryDto> SubCategories { get; set; } = [];
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, GetCategoryDto>()
                .ForMember(dest => dest.SubCategories, opt => opt.MapFrom(x => x.SubCategories));
        }
    }
}
