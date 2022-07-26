using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Models.DTOs.AuthorDTO;

namespace BlogAPI.Mapper
{
    public class AuthorCreateMapper : Profile
    {
        public AuthorCreateMapper()
        {
            CreateMap<Author, CreateAuthorDTO>()
               .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
               .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName))
               .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
               .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.Age));
        }
    }
}
