using BlogAPI.Models.DTOs.PostDTO;
using FluentValidation;

namespace BlogAPI.Validators.Post
{
    public class CreatePostValidator : AbstractValidator<CreatePostDTO>
    {
        public CreatePostValidator()
        {
            RuleFor(x => x.Title).NotNull().Length(1, 30);
            RuleFor(x => x.Content).NotNull().Length(1, 200);
        }
    }
}
