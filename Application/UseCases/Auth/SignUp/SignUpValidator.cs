using FluentValidation;
using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Auth.SignUp
{
    public class SignUpValidator : AbstractValidator<SignUpInputDTO>
    {
        public SignUpValidator()
        {
            RuleFor(x => x.FirstName)
                .MaximumLength(50).WithMessage(Messages.FirstNameMaxLength)
                .MinimumLength(3).WithMessage(Messages.FirstNameMinLength);

            RuleFor(x => x.LastName)
                .MaximumLength(50).WithMessage(Messages.LastNameMaxLength)
                .MinimumLength(2).WithMessage(Messages.LastNameMinLength);

            RuleFor(x => x.Phone)
                .NotNull().WithMessage(Messages.PhoneRequired)
                .Must(p =>
                     p.StartsWith("09") &&
                     p.Length == 11 &&
                     p.All(char.IsDigit))
                .WithMessage(Messages.PhoneInvalid);

            RuleFor(x => x.UserName)
                .NotNull().WithMessage(Messages.UserNameRequired)
                .MinimumLength(6).WithMessage(Messages.UserNameMinLength)
                .Matches(@"^[^\u0600-\u06FF]+$")
                .WithMessage(Messages.UsernameNotFarsi);

            RuleFor(x => x.Password1)
                .NotNull().WithMessage(Messages.Password1Required)
                .MinimumLength(5).WithMessage(Messages.Password1Powerful);

            RuleFor(x => x.Password2)
                .NotEmpty().WithMessage(Messages.Password2Required)
                .Equal(x => x.Password1)
                .WithMessage(Messages.PasswordsDoNotMatch);
        }
    }
}
