using FluentValidation;
using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Sellers.UpdateSeller
{
    public class SellerUpdateValidator: AbstractValidator<SellerUpdateInputDTO>
    {
        public SellerUpdateValidator()
        {
            RuleFor(x => x.FirstName)
                .MinimumLength(3).WithMessage(Messages.FirstNameMinLength)
                .MaximumLength(50).WithMessage(Messages.FirstNameMaxLength);

            RuleFor(x => x.LastName)
                .MinimumLength(2).WithMessage(Messages.LastNameMinLength)
                .MaximumLength(50).WithMessage(Messages.LastNameMaxLength);

                RuleFor(x => x.Phone)
                .NotNull().WithMessage(Messages.PhoneRequired)
                .Must(p =>
                     p.StartsWith("09") &&
                     p.Length == 11 &&
                     p.All(char.IsDigit))
                .WithMessage(Messages.PhoneInvalid);

            RuleFor(x => x.NewUsername)
                .NotNull().WithMessage(Messages.UserNameRequired)
                .MinimumLength(6).WithMessage(Messages.UserNameMinLength)
                .Matches(@"^[^\u0600-\u06FF]+$")
                .WithMessage(Messages.UsernameNotFarsi);

            RuleFor(x => x.Password)
                .NotNull().WithMessage(Messages.Password1Required)
                .MinimumLength(5).WithMessage(Messages.Password1Powerful);

            RuleFor(x => x.Address)
                .NotNull().WithMessage(Messages.AddressRequired)
                .MaximumLength(500).WithMessage(Messages.AddressMaxLength);

            RuleFor(x => x.ProfileImage)
                .NotNull().WithMessage(Messages.ProfileImageRequired);

            RuleFor(x => x.WorkHistory)
                .MinimumLength(1).WithMessage(Messages.WorkHistoryMinlength)
                .MaximumLength(3).WithMessage(Messages.WorkHistoryMaxLength);
        }
    }
}
