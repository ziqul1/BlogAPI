using AutoMapper;
using BlogAPI.Models;
using BlogAPI.Models.DTOs.CategoryDTO;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Data.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly BlogContext _blogContext;
        private readonly IMapper _mapper;

        public CategoryService(BlogContext blogContext, IMapper mapper)
        {
            _blogContext = blogContext;
            _mapper = mapper;
        }

        public async Task<List<CategoryDTO>> GetCategoriesAsync()
        {
            return await _blogContext.Categories.Select(x => _mapper.Map<CategoryDTO>(x)).ToListAsync();
        }

        public async Task<CategoryDTO> GetSingleCategoryAsync(int id)
        {
            return await _blogContext.Categories.Where(x => x.Id == id)
                .Select(x => _mapper.Map<CategoryDTO>(x)).FirstOrDefaultAsync();
        }

        public async Task<long> UpdateCategoryAsync(int id, CategoryDTO categoryDTO)
        {
            var category = await _blogContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            // Tutaj to da sie za pomoca auto mappera jakos fik siup?
            category.Name = categoryDTO.Name;

            return await _blogContext.SaveChangesAsync();
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CategoryDTO categoryDTO)
        {
            // Tu chyba można napisać jeszcze mapowanie z DTO na zwykłego ale mi sie nie chciało ;/
            var category = new Models.Category
            {
                Name = categoryDTO.Name,
            };

            _blogContext.Categories.Add(category);
            await _blogContext.SaveChangesAsync();

            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task<bool> DeleteCategoryAsync(int id)
        {
            var category = await _blogContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            _blogContext.Categories.Remove(category);

            return await _blogContext.SaveChangesAsync() > 0;
        }
    }
}
