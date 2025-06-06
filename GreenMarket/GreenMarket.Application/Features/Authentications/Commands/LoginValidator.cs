using FluentValidation;

namespace GreenMarket.Application.Features.Authentications.Commands
{
    public class LoginValidator : AbstractValidator<LoginCommand>
    {
        public LoginValidator() {
            RuleFor(x => x.Gmail)
                .NotEmpty().WithMessage("Gmail không được để trống")
                .EmailAddress().WithMessage("Gmail phải đúng định dạng");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password không được để trống");
        }
    }
}
