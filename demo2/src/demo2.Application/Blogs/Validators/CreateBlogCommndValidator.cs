using demo2.Application.Blogs.Commands.CreateBlog;
using FluentValidation;

namespace demo2.Application.Blogs.Validators
{
    public class CreateBlogCommndValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommndValidator()
        {
            RuleFor(a => a.Url)
                .NotEmpty()
                .WithMessage("O Url é obrigatório");
        }
    }
}
