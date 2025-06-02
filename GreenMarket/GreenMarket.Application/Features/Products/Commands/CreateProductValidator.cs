using FluentValidation;

namespace GreenMarket.Application.Features.Products.Commands
{
    public class CreateProductValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Tên sản phẩm không được để trống")
                .MaximumLength(100).WithMessage("Tên sản phẩm không được vượt quá 100 ký tự");

            RuleFor(x => x.UnitPrice)
                .GreaterThan(0).WithMessage("Đơn giá phải lớn hơn 0");
        }
    }
}
