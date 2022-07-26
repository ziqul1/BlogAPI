using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Models.DTOs.CategoryDTO;

namespace BlogAPI.Mapper
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            CreateMap<Category, CategoryDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
