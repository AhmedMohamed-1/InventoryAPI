using FluentValidation;
using CRUD_API.DTOs.ProductDTOs;

namespace CRUD_API.ValidatorClasses.ProductValidatorClasses
{
    public class CreateProductDtoValidator : AbstractValidator<CreateProductDto>
    {
        public CreateProductDtoValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("Product name is required.")
                .Length(2, 100)
                .WithMessage("Product name must be between 2 and 100 characters.");
            RuleFor(p => p.Price)
                .GreaterThan(0)
                .WithMessage("Product price must be greater than zero.");
            RuleFor(p => p.CategoryId)
                .NotEmpty()
                .WithMessage("Category ID is required.")
                .GreaterThan(0)
                .WithMessage("Category ID must be a positive integer");
            RuleFor(p => p.Quantity)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Product quantity must be greater than or equal to zero.");
            RuleFor(p => p.SupplierId)
                .GreaterThan(0)
                .WithMessage("Supplier ID must be a positive integer.")
                .When(p => p.SupplierId.HasValue); // Apply validation only if SupplierId is provided
        }
    }
}
