using BlogAPI.Models;
using BlogAPI.Models.DTOs.AuthorDTO;
using BlogAPI.Models.DTOs.PostDTO;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly BlogContext _blogContext;

        public AuthorService(BlogContext blogContext)
            => _blogContext = blogContext;

        public async Task<List<GetSingleAuthorDTO>> GetAuthorsAsync()
        {
            return await _blogContext.Authors.Select(x => new GetSingleAuthorDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Age = x.Age,
                AuthorMTMPosts = x.AuthorMTMPosts.Select(y => new GetSinglePostDTO
                {
                    Id = y.PostId,
                    Title = y.Post.Title,
                    Content = y.Post.Content,
                    CategoryId = y.Post.CategoryId,
                    CategoryName = y.Post.Category.Name
                }).ToList(),
            }).ToListAsync();
        }

        public async Task<GetSingleAuthorDTO> GetSingleAuthorAsync(int id)
        {
            return await _blogContext.Authors.Where(x => x.Id == id).Select(x => new GetSingleAuthorDTO
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Age = x.Age,
                AuthorMTMPosts = x.AuthorMTMPosts.Select(y => new GetSinglePostDTO
                {
                    Id = y.PostId,
                    Title = y.Post.Title,
                    Content = y.Post.Content,
                    CategoryId = y.Post.CategoryId,
                    CategoryName = y.Post.Category.Name
                }).ToList(),
            }).FirstOrDefaultAsync();
        }

        public async Task<long> UpdateAuthorAsync(int id, UpdateAuthorDTO authorDTO)
        {
            var author = await _blogContext.Authors.FirstOrDefaultAsync(x => x.Id == id);

            author.FirstName = authorDTO.FirstName;
            author.LastName = authorDTO.LastName;
            author.Email = authorDTO.Email;
            author.Age = authorDTO.Age;

            return await _blogContext.SaveChangesAsync();
        }
    }
}
