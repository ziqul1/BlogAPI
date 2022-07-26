using BlogAPI.Models;
using BlogAPI.Models.DTOs.CategoryDTO;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _blogContext;

        public CategoryService(BlogContext blogContext)
            => _blogContext = blogContext;

        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            return await _blogContext.Categories.Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).ToListAsync();
        }

        public async Task<CategoryDTO> GetSingleCategoryAsync(int id)
        {
            return await _blogContext.Categories.Where(x => x.Id == id).Select(x => new CategoryDTO
            {
                Id = x.Id,
                Name = x.Name,
            }).FirstOrDefaultAsync();
        }

        public async Task<long> UpdateCategoryAsync(int id, CategoryDTO categoryDTO)
        {
            var category = await _blogContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            category.Name = categoryDTO.Name;

            return await _blogContext.SaveChangesAsync();
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            var category = new Models.Category
            {
                Name = categoryDTO.Name,
            };

            _blogContext.Categories.Add(category);
            await _blogContext.SaveChangesAsync();

            return new CategoryDTO
            {
                Id = category.Id,
                Name = category.Name,
            };
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _blogContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            _blogContext.Categories.Remove(category);

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
