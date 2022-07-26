using BlogAPI.Models.DTOs.AuthorDTO;
using FluentValidation;

namespace BlogAPI.Validators.Author
{
    public class CreateAuthorValidator : AbstractValidator<CreateAuthorDTO>
    {
        public CreateAuthorValidator()
        {
            RuleFor(x => x.FirstName).NotNull().Length(1, 20);
            RuleFor(x => x.LastName).NotNull().Length(1, 20);
            RuleFor(x => x.Email).NotNull().Length(1, 50);
            RuleFor(x => x.Age).NotNull().InclusiveBetween(18, 120);
        }
    }
}
