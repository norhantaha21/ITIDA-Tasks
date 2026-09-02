using FluentValidation;
using TaskApi.Dtos;

namespace TaskApi.Validators
{
    public class CreateTaskRequestValidator : AbstractValidator<CreateTaskRequestDto>

    {
        public CreateTaskRequestValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters")
                .Must(NotContainHtmlTags).WithMessage("Title must not contain HTML tags");

            When(x => x.DueDate.HasValue, () =>
            {
                RuleFor(x => x.DueDate)
                    .GreaterThan(DateTime.Now).WithMessage("Due date must be in the future");
            });
        }

        private bool NotContainHtmlTags(string title)
            => !System.Text.RegularExpressions.Regex.IsMatch(title ?? "", "<.*?>");
    }
}
