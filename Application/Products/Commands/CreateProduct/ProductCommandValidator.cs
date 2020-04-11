using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Products.Commands.CreateProduct
{
    public abstract class ProductCommandValidator : AbstractValidator<ProductCommand>
    {
        public ProductCommandValidator()
        {
            RuleFor(v => v.CategoryId).GreaterThan(0);
            RuleFor(v => v.QuantityPerUnit).GreaterThanOrEqualTo(0);
            RuleFor(v => v.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(v => v.UnitsInStock).GreaterThanOrEqualTo(0);
        }
    }
}
