using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Models.DTOs.AuthorDTO;
using BlogAPI.Models.DTOs.PostDTO;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data.Services.Author
{
    public class AuthorService : IAuthorService
    {
        private readonly BlogContext _blogContext;
        private readonly IMapper _mapper;

        public AuthorService(BlogContext blogContext, IMapper mapper)
        {
            _blogContext = blogContext;
            _mapper = mapper;
        }

        public async Task<List<GetSingleAuthorDTO>> GetAuthorsAsync()
        {
            return await _blogContext.Authors
                .Include(x => x.AuthorMTMPosts)
                .ThenInclude(x => x.Post)
                .ThenInclude(x => x.Category)
                .Select(x => _mapper.Map<GetSingleAuthorDTO>(x))
                .ToListAsync();
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

        public async Task<CreateAuthorDTO> CreateAuthorAsync(CreateAuthorDTO authorDTO)
        {
            var author = new Models.Author
            {
                FirstName = authorDTO.FirstName,
                LastName = authorDTO.LastName,
                Email = authorDTO.Email,
                Age = authorDTO.Age,
            };

            _blogContext.Authors.Add(author);
            await _blogContext.SaveChangesAsync();

            return _mapper.Map<CreateAuthorDTO>(author);
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            var author = await _blogContext.Authors.Include(x => x.AuthorMTMPosts).FirstOrDefaultAsync(x => x.Id == id);

            var listOfPosts = author.AuthorMTMPosts;

            foreach (var post in listOfPosts)
            {
                var tempPost = await _blogContext.Posts.Include(x => x.AuthorMTMPosts).FirstOrDefaultAsync(x => x.Id == post.PostId);

                if (tempPost.AuthorMTMPosts.Count == 1)
                    _blogContext.Posts.Remove(tempPost);
            }

            _blogContext.Authors.Remove(author);
            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
