using BlogAPI.Models.DTOs.CategoryDTO;

namespace BlogAPI.Data.Services.Category
{
    public interface ICategoryService
    {
        public Task<List<CategoryDTO>> GetCategoriesAsync();
        public Task<CategoryDTO> GetSingleCategoryAsync(int id);
        public Task<long> UpdateCategoryAsync(int id, CategoryDTO categoryDTO);
        public Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDTO);
        public Task<bool> DeleteCategoryAsync(int id);
    }
}
