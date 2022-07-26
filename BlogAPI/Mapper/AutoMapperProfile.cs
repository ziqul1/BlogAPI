using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Models.DTOs.AuthorDTO;
using BlogAPI.Models.DTOs.CategoryDTO;
using BlogAPI.Models.DTOs.PostDTO;

namespace BlogAPI.Mapper
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Category, CategoryDTO>();

            CreateMap<Author, CreateAuthorDTO>();
            CreateMap<Author, GetSingleAuthorDTO>();
            CreateMap<Author, UpdateAuthorDTO>();

            CreateMap<Post, CreatePostDTO>();
            CreateMap<Post, GetSinglePostDTO>();
            CreateMap<Post, UpdatePostDTO>();
        }
    }
}
