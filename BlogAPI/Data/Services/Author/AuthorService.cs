using BlogAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly BlogContext _blogContext;

        public AuthorService(BlogContext blogContext) 
            => _blogContext = blogContext;

        // pozniej zmienic na DTO 
        public async Task<IEnumerable<Models.Author>> GetAuthorsAsync()
        {
            return await _blogContext.Authors
                .Select(x => new Models.Author
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    Age = x.Age,
                    // dodac co nizej
                    //AuthorMTMPosts = x.AuthorMTMPosts.Select(y => new )
                })
                .ToListAsync();
        }
    }
}
