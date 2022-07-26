using BlogAPI.Models;
using BlogAPI.Models.DTOs.PostDTO;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data.Services.Post
{
    public class PostService : IPostService
    {
        private readonly BlogContext _blogContext;

        public PostService(BlogContext blogContext)
            => _blogContext = blogContext;

        public async Task<List<GetSinglePostDTO>> GetPostsAsync()
        {
            return await _blogContext.Posts.Select(x => new GetSinglePostDTO
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name
            }).ToListAsync();
        }

        public async Task<GetSinglePostDTO> GetSinglePostAsync(int id)
        {
            return await _blogContext.Posts.Where(x => x.Id == id).Select(x => new GetSinglePostDTO
            {
                Id = x.Id,
                Title = x.Title,
                Content = x.Content,
                CategoryId = x.CategoryId,
                CategoryName = x.Category.Name
            }).FirstOrDefaultAsync();
        }

        //public async Task<long> UpdatePostAsync(int id, UpdatePostDTO postDTO)
        //{
        //    var post = await _blogContext.Posts.FirstOrDefaultAsync(x => x.Id == id);

        //    post.FirstName = postDTO.FirstName;
        //    post.LastName = postDTO.LastName;
        //    post.Email = postDTO.Email;
        //    post.Age = postDTO.Age;

        //    return await _blogContext.SaveChangesAsync();
        //}

        public async Task<CreatePostDTO> CreatePostAsync(CreatePostDTO postDTO)
        {
            var post = new Models.Post
            {
                Id = postDTO.Id,
                Title  = postDTO.Title,
                Content = postDTO.Content,
                CategoryId= postDTO.CategoryId,
            };

            var authors = await _blogContext.Authors.AsNoTracking()
                .Where(x => postDTO.AuthorIds.Contains(x.Id)).Select(x => x.Id).ToListAsync();

            post.AuthorMTMPosts = authors.Select(x => new AuthorMTMPost
            {
                AuthorId = x
            }).ToList();

            _blogContext.Posts.Add(post);
            await _blogContext.SaveChangesAsync();

            return new CreatePostDTO
            {
                Id = post.Id,
                Title = post.Title,
                Content = post.Content,
                CategoryId = post.CategoryId,
                AuthorIds = post.AuthorMTMPosts.Select(x => x.AuthorId).ToList(),
            };
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await _blogContext.Posts.Where(x => x.Id == id).FirstOrDefaultAsync(x => x.Id == id);

            _blogContext.Posts.Remove(post);

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
