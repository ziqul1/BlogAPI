using BlogAPI.Data.Services.Author;
using BlogAPI.Models.DTOs.AuthorDTO;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
            => _authorService = authorService;

        // GET: api/Author
        [HttpGet]
        public async Task<IActionResult> GetAuthorsAsync()
        {
            return Ok(await _authorService.GetAuthorsAsync());
        }

        // GET: api/Author/1
        [HttpGet("{id}")]
        public async Task<ActionResult<GetSingleAuthorDTO>> GetSingleAuthorAsync(int id)
        {
            var author = await _authorService.GetSingleAuthorAsync(id);

            if (author == null)
                return NotFound();

            return author;
        }

        // PUT: api/Author/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthorAsync(int id, UpdateAuthorDTO authorDTO)
        {
            var author = await _authorService.UpdateAuthorAsync(id, authorDTO);

            if (author == null)
                return NotFound();

            await _authorService.UpdateAuthorAsync(id, authorDTO);

            return NoContent();
        }

    }
}
