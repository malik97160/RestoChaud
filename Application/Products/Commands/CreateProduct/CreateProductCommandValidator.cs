using FluentValidation;

namespace Application.Products.Commands.CreateProduct
{
    public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
    {
        public CreateProductCommandValidator()
        {
            Include(new ProductCommandValidator());
        }
    }
}
