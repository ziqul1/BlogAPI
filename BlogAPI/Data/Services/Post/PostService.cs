using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Models.DTOs.PostDTO;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data.Services.Post
{
    public class PostService : IPostService
    {
        private readonly BlogContext _blogContext;
        private readonly IMapper _mapper;


        public PostService(BlogContext blogContext, IMapper mapper)
        {
            _blogContext = blogContext;
            _mapper = mapper;
        }

        public async Task<List<GetSinglePostDTO>> GetPostsAsync()
        {
            return await _blogContext.Posts.Include(x => x.Category).Select(x => _mapper.Map<GetSinglePostDTO>(x)).ToListAsync();
        }

        public async Task<GetSinglePostDTO> GetSinglePostAsync(int id)
        {
            return await _blogContext.Posts.Include(x => x.Category)
                .Where(x => x.Id == id)
                .Select(x => _mapper.Map<GetSinglePostDTO>(x))
                .FirstOrDefaultAsync();
        }

        public async Task<long> UpdatePostAsync(int id, UpdatePostDTO postDTO)
        {
            var post = await _blogContext.Posts.Include(x => x.AuthorMTMPosts).FirstOrDefaultAsync(x => x.Id == id);

            post.Title = postDTO.Title;
            post.Content = postDTO.Content;
            post.CategoryId = postDTO.CategoryId;
            post.AuthorMTMPosts.Clear();
            post.AuthorMTMPosts = postDTO.AuthorIds.Select(x => new AuthorMTMPost
            {
                AuthorId = x
            }).ToList();

            return await _blogContext.SaveChangesAsync();
        }

        public async Task<CreatePostDTO> CreatePostAsync(CreatePostDTO postDTO)
        {
            var post = new Models.Post
            {
                Id = postDTO.Id,
                Title = postDTO.Title,
                Content = postDTO.Content,
                CategoryId = postDTO.CategoryId,
            };

            var authors = await _blogContext.Authors.AsNoTracking()
                .Where(x => postDTO.AuthorIds.Contains(x.Id)).Select(x => x.Id).ToListAsync();

            post.AuthorMTMPosts = authors.Select(x => new AuthorMTMPost
            {
                AuthorId = x
            }).ToList();

            _blogContext.Posts.Add(post);
            await _blogContext.SaveChangesAsync();

            return _mapper.Map<CreatePostDTO>(post);
        }

        public async Task<bool> DeletePostAsync(int id)
        {
            var post = await _blogContext.Posts.Where(x => x.Id == id).FirstOrDefaultAsync(x => x.Id == id);

            _blogContext.Posts.Remove(post);

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
