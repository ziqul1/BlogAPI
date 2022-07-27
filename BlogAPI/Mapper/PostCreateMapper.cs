using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Models.DTOs.PostDTO;

namespace BlogAPI.Mapper
{
    public class PostCreateMapper : Profile
    {
        public PostCreateMapper()
        {
            CreateMap<Post, CreatePostDTO>()
             .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
             .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
             .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryId))
             .ForMember(dest => dest.AuthorIds, opt => opt.MapFrom(src => src.AuthorMTMPosts
             .Select(x => x.AuthorId).ToList()));
        }
    }
}
