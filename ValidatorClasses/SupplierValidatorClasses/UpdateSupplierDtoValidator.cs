using FluentValidation;
using CRUD_API.DTOs.SupplierDTOs;

namespace CRUD_API.ValidatorClasses.SupplierValidatorClasses
{
    public class UpdateSupplierDtoValidator : AbstractValidator<UpdateSupplierDto>
    {
        public UpdateSupplierDtoValidator()
        {
            RuleFor(s => s.Name)
                .NotEmpty()
                .WithMessage("Supplier name is required for update.")
                .Length(2, 100)
                .WithMessage("Supplier name must be between 2 and 100 characters.")
                .When(s => !string.IsNullOrEmpty(s.Name));

            RuleFor(s => s.ContactEmail)
                .EmailAddress()
                .WithMessage("Invalid email address format.")
                .When(s => !string.IsNullOrEmpty(s.ContactEmail));

            RuleFor(s => s.Phone)
                .Matches(@"^\+?[0-9]{10,15}$")
                .WithMessage("Phone number must be between 10 and 15 digits and may start with +.")
                .When(s => !string.IsNullOrEmpty(s.Phone));
        }
    }
}
