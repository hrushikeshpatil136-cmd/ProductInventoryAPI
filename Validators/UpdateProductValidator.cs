using FluentValidation;
using ProductInventoryAPI.DTOs;

namespace ProductInventoryAPI.Validators
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.ProductName)
                .NotEmpty()
                .WithMessage("Product Name is required.")
                .MaximumLength(255);

            RuleFor(x => x.ModifiedBy)
                .NotEmpty()
                .WithMessage("Modified By is required.");
        }
    }
}