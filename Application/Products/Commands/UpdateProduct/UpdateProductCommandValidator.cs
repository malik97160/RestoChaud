using FluentValidation;

namespace Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            Include(new ProductCommandValidator());
            RuleFor(v => v.ProductId).GreaterThan(0);
        }
    }
}
