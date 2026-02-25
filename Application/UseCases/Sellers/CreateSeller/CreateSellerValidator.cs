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
                .NotEmpty().WithMessage(Messages.UserNameMinLength)
                .MinimumLength(6).WithMessage(Messages.UserNameMinLength)
                .MaximumLength(50).WithMessage(Messages.UserNameMaxLength);

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(Messages.AddressRequired)
                .MaximumLength(500).WithMessage(Messages.AddressMaxLength);

            RuleFor(x => x.ProfileImage)
                .NotEmpty().WithMessage(Messages.ProfileImageRequired);

            RuleFor(x => x.WorkHistory)
                .MinimumLength(1).WithMessage(Messages.WorkHistoryMinlength)
                .MaximumLength(3).WithMessage(Messages.WorkHistoryMaxLength);
        }
    }
}
