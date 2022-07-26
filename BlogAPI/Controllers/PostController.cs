using BlogAPI.Data.Services.Post;
using BlogAPI.Models.DTOs.PostDTO;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
            => _postService = postService;

        // GET: api/Post
        [HttpGet]
        public async Task<IActionResult> GetPostAsync()
        {
            return Ok(await _postService.GetPostsAsync());
        }

        // GET: api/Post/1
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSinglePostDTO>> GetSinglePostAsync(int id)
        {
            var post = await _postService.GetSinglePostAsync(id);

            if (post == null)
                return NotFound();

            return post;
        }

        // PUT: api/Post/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePostAsync(int id, UpdatePostDTO postDTO)
        {
            var post = await _postService.UpdatePostAsync(id, postDTO);

            if (post == null)
                return NotFound();

            await _postService.UpdatePostAsync(id, postDTO);

            return NoContent();
        }

        // POST: api/Post
        [HttpPost]
        public async Task<ActionResult<CreatePostDTO>> CreatePostAsync(CreatePostDTO postDTO)
        {
            var post = await _postService.CreatePostAsync(postDTO);

            return CreatedAtAction(
                nameof(GetSinglePostAsync),
                new { id = post.Id },
                post
                );
        }

        // DELETE: api/Post/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePostAsync(int id)
        {
            var post = await _postService.GetSinglePostAsync(id);

            if (post == null)
                return NotFound();

            if (await _postService.DeletePostAsync(id))
                return NoContent();

            return BadRequest();
        }
    }
}
