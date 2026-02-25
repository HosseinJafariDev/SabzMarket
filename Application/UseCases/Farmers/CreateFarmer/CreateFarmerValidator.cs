using FluentValidation;
using SabzMarket.Application.Common;
using SabzMarket.Application.Common.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Farmers.CreateFarmer
{
    public class CreateFarmerValidator : AbstractValidator<CreateFarmerInputDTO>
    {
        public CreateFarmerValidator()
        {

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage(Messages.AddressRequired)
                .MaximumLength(500).WithMessage(Messages.AddressMaxLength);

            RuleFor(x => x.DataBuilt)
                .Length(10).WithMessage(Messages.EnterDataBuilt);

            RuleFor(x => x.LandArea)
                .GreaterThan(0).WithMessage(Messages.EnterLandArea);

            RuleFor(x => x.NationalCode)
                .NotEmpty().WithMessage(Messages.NationalCodeRequired)
                .Must(NationalCodeValidator.IsValid!).WithMessage(Messages.NotValidNationalCode);

            RuleFor(x => x.CodParvaneBHB)
                .Length(14).WithMessage(Messages.EnterCodParvaneBHB);

            RuleFor(x => x.ProfileImage)
                .NotEmpty().WithMessage(Messages.ProfileImageRequired);

            RuleFor(x => x.CodePosti)
                .Length(10).WithMessage(Messages.EnterCodePosti);
        }
    }
}
