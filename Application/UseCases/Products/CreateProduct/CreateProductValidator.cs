using FluentValidation;
using SabzMarket.Application.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SabzMarket.Application.UseCases.Products.CreateProduct
{
    public class CreateProductValidator: AbstractValidator<CreateProductInputDTO>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(Messages.ProductNameRequired);

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage(Messages.ProductDescriptionRequired)
                .MaximumLength(500).WithMessage(Messages.ProductDescriptionMaxLength);

            RuleFor(x=>x.Number)
                .NotEmpty().WithMessage(Messages.ProductNumberRequired);

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage(Messages.ProductPriceRequired);

            RuleFor(x => x.ImageProduct)
                .NotEmpty().WithMessage(Messages.ProductImageRequired);
        }
    }
}
