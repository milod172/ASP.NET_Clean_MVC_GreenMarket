using FluentValidation;

namespace GreenMarket.Application.Features.Categories.Commands
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator() {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Tên danh mục không được để trống")
                .MaximumLength(100).WithMessage("Tên danh mục không được vượt quá 100 ký tự");

        }
    }
}
