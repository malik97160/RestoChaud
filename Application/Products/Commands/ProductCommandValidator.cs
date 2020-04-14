using FluentValidation;

namespace Application.Products.Commands
{
    public class ProductCommandValidator : AbstractValidator<ProductCommand>
    {
        public ProductCommandValidator()
        {
            RuleFor(v => v.CategoryId).GreaterThan(0);
            RuleFor(v => v.QuantityPerUnit).GreaterThanOrEqualTo(0);
            RuleFor(v => v.UnitPrice).GreaterThanOrEqualTo(0);
            RuleFor(v => v.UnitsInStock).GreaterThanOrEqualTo(0);
            RuleFor(v => v.ProductName).NotNull().NotEmpty().MaximumLength(100);
        }
    }
}
