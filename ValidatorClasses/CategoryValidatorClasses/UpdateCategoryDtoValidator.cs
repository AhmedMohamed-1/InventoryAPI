using CRUD_API.DTOs.CategoryDTOs;
using FluentValidation;

namespace CRUD_API.ValidatorClasses.CategoryValidatorClasses
{
    public class UpdateCategoryDtoValidator : AbstractValidator<UpdateCategoryDto>
    {
        public UpdateCategoryDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Category name is required for update.")
                .Length(2, 50)
                .WithMessage("Category name must be between 2 and 50 characters.")
                .When(c => !string.IsNullOrEmpty(c.Name));  // Ensure the rule is applied only when name is provided
        }
    }
}
