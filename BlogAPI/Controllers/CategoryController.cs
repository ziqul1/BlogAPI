using BlogAPI.Data.Services.Category;
using BlogAPI.Models.DTOs.CategoryDTO;
using Microsoft.AspNetCore.Mvc;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
            => _categoryService = categoryService;

        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> GetCategorysAsync()
        {
            return Ok(await _categoryService.GetCategoriesAsync());
        }

        // GET: api/Category/1
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetSingleCategoryAsync(int id)
        {
            var category = await _categoryService.GetSingleCategoryAsync(id);

            if (category == null)
                return NotFound();

            return category;
        }

        // PUT: api/Category/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategoryAsync(int id, CategoryDTO categoryDTO)
        {
            var category = await _categoryService.UpdateCategoryAsync(id, categoryDTO);

            if (category == null)
                return NotFound();

            await _categoryService.UpdateCategoryAsync(id, categoryDTO);

            return NoContent();
        }

        // POST: api/Category
        [HttpPost]
        public async Task<ActionResult<CategoryDTO>> CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = await _categoryService.CreateCategoryAsync(categoryDTO);

            return CreatedAtAction(
                nameof(GetSingleCategoryAsync),
                new { id = category.Id },
                category
                );
        }

        // DELETE: api/Category/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoryAsync(int id)
        {
            var category = await _categoryService.GetSingleCategoryAsync(id);
            if (category == null)
                return NotFound();

            if (await _categoryService.DeleteCategoryAsync(id))
                return NoContent();

            return BadRequest();
        }
    }
}
