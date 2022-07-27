using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Models.DTOs.AuthorDTO;
using BlogAPI.Models.DTOs.PostDTO;

namespace BlogAPI.Mapper
{
    public class AuthorGetSingleMapper : Profile
    {
        public AuthorGetSingleMapper()
        {
            CreateMap<AuthorMTMPost, GetSinglePostDTO>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Post.Id))
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Post.Title))
               .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Post.Content))
               .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.Post.CategoryId))
               .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Post.Category.Name));

            CreateMap<Author, GetSingleAuthorDTO>()
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));
        }
    }
}
