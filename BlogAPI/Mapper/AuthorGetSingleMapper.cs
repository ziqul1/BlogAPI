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
            CreateMap<Author, GetSingleAuthorDTO>()
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age))
               .ForMember(dest => dest.AuthorMTMPosts, opt => opt.MapFrom(src => src.AuthorMTMPosts
                .Select(x => x.Post).Select(x => new GetSinglePostDTO
                {
                    Id = y.PostId // czy jakos tak
                }).ToList()));


        }

    //    Id = x.Id,
    //            FirstName = x.FirstName,
    //            LastName = x.LastName,
    //            Email = x.Email,
    //            Age = x.Age,
    //            AuthorMTMPosts = x.AuthorMTMPosts.Select(y => new GetSinglePostDTO
    //            {
    //                Id = y.PostId,
    //                Title = y.Post.Title,
    //                Content = y.Post.Content,
    //                CategoryId = y.Post.CategoryId,
    //                CategoryName = y.Post.Category.Name
    //}).ToList(),
    }
}
