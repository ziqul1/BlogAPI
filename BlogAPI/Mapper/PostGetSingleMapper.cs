using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Models.DTOs.PostDTO;

namespace BlogAPI.Mapper
{
    public class PostGetSingleMapper : Profile
    {
        public PostGetSingleMapper()
        {
            CreateMap<Post, GetSinglePostDTO>()
              .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
              .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
              .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
              .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category.Name));
            // gunzo nie wyswietla Category.Name - wypisuje null
        }
    }
}
