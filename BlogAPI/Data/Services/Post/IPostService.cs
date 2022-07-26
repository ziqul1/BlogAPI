using BlogAPI.Models.DTOs.PostDTO;

namespace BlogAPI.Data.Services.Post
{
    public interface IPostService
    {
        public Task<List<GetSinglePostDTO>> GetPostsAsync();
        public Task<GetSinglePostDTO> GetSinglePostAsync(int id);
        public Task<long> UpdatePostAsync(int id, UpdatePostDTO postDTO);
        public Task<CreatePostDTO> CreatePostAsync(CreatePostDTO postDTO);
        public Task<bool> DeletePostAsync(int id);
    }
}
