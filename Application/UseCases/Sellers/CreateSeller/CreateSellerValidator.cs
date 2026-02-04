using FluentValidation;
using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Sellers.CreateSeller
{
    public class CreateSellerValidator:AbstractValidator<CreateSellerInputDTO>
    {
        public CreateSellerValidator()
        {
            RuleFor(x => x.Username)
                .NotNull().WithMessage(Messages.UserNameMinLength)
                .MinimumLength(6).WithMessage(Messages.UserNameMinLength)
                .MaximumLength(50).WithMessage(Messages.UserNameMaxLength);

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
