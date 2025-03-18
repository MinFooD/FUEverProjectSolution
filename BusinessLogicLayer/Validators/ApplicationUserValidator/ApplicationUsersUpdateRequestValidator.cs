using BusinessLogicLayer.Dtos.ApplicationUsersDtos;
using FluentValidation;

namespace BusinessLogicLayer.Validators.ApplicationUserValidator;

public class ApplicationUsersUpdateRequestValidator : AbstractValidator<ApplicationUsersUpdateRequest>
{
    public ApplicationUsersUpdateRequestValidator()
    {
        RuleFor(x => x.UserName)
            .NotEmpty().WithMessage("UserName is required")
            .MaximumLength(256).WithMessage("UserName must not exceed 256 characters");

        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Email must be a valid email address")
            .MaximumLength(256).WithMessage("Email must not exceed 256 characters");

        RuleFor(x => x.ProfileImage)
            .MaximumLength(255).WithMessage("ProfileImage URL must not exceed 255 characters");

        RuleFor(x => x.DateOfBirth)
            .NotEmpty().WithMessage("DateOfBirth is required")
            .LessThanOrEqualTo(DateTime.Today).WithMessage("DateOfBirth cannot be in the future");

        RuleFor(x => x.Address)
            .MaximumLength(500).WithMessage("Address must not exceed 500 characters");
    }
}
