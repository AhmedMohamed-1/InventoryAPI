using CRUD_API.DTOs.ProductDTOs;
using FluentValidation;

namespace CRUD_API.ValidatorClasses.ProductValidatorClasses
{
    public class UpdateProductDtoValidator : AbstractValidator<UpdateProductDto>
    {
        public UpdateProductDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Product name is required for update.")
                .Length(2, 100)
                .WithMessage("Product name must be between 2 and 100 characters.")
                .When(p => !string.IsNullOrEmpty(p.Name));  // Ensure the rule is applied only when name is provided

            RuleFor(p => p.Price)
                .GreaterThan(0)
                .WithMessage("Product price must be greater than zero.")
                .When(p => p.Price > 0);  // Apply validation only if Price is provided and positive

            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Product quantity must be greater than or equal to zero.");

            RuleFor(p => p.CategoryId)
                .GreaterThan(0)
                .WithMessage("Category ID must be a positive integer.");

            RuleFor(p => p.SupplierId)
                .GreaterThan(0)
                .WithMessage("Supplier ID must be a positive integer.")
                .When(p => p.SupplierId.HasValue); // Apply validation only if SupplierId is provided
        }
    }
}
