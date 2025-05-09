using FluentValidation;
using CRUD_API.DTOs.CategoryDTOs;

namespace CRUD_API.ValidatorClasses.CategoryValidatorClasses
{
    public class CreateCategoryDtoValidator : AbstractValidator<CreateCategoryDto>
    {
        public CreateCategoryDtoValidator()
        {
            RuleFor(c => c.Name)
                .NotEmpty()
                .WithMessage("Category name is required.")
                .Length(2, 50)
                .WithMessage("Category name must be between 2 and 50 characters.");
        }
    }
}
