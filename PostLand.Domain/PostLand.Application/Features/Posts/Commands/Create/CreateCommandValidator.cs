using FluentValidation;

namespace PostLand.Application.Features.Posts.Commands.Create;

public class CreateCommandValidator:AbstractValidator<CreatePost>
{
    public CreateCommandValidator()
    {
        RuleFor(p => p.Title).NotEmpty().NotNull().MaximumLength(100);
        RuleFor(p=>p.Content).NotEmpty().NotNull();
    }
}
