using BlogAPI.Models.DTOs.CategoryDTO;
using FluentValidation;

namespace BlogAPI.Validators.Category
{
    public class CreateCategoryValidator : AbstractValidator<CategoryDTO>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().Length(1, 20);
        }
    }
}
