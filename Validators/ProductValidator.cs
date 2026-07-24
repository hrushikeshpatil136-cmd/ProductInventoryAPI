using FluentValidation;
using ProductInventoryAPI.DTOs;

namespace ProductInventoryAPI.Validators
{
    public class ProductValidator : AbstractValidator<CreateProductDto>
    {
        public ProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty().WithMessage("Product Name is required.")
                .MaximumLength(255);

            RuleFor(x => x.CreatedBy)
                .NotEmpty().WithMessage("Created By is required.");
        }
    }
}
