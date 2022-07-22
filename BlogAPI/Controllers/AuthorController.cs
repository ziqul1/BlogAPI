using BlogAPI.Data.Services.Author;
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

        // GET: api/Authors
        [HttpGet]
        public async Task<IActionResult> GetAuthorsAsync()
        {
            return Ok(await _authorService.GetAuthorsAsync());
        }
    }
}
