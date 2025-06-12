using FluentValidation;
using Qurbanet.Extensions;
using Qurbanet.Models.DTOs.User;

namespace Qurbanet.Validators.User
{
    public class UpdateUserDtoValidator : AbstractValidator<UpdateUserDto>
    {
        public UpdateUserDtoValidator()
        {
            RuleFor(x => x.Name).ApplyNameRules();

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .MaximumLength(50).WithMessage("Surname cannot exceed 50 characters.");

            RuleFor(x => x.Email).ApplyEmailRules();

            RuleFor(x => x.Phone).ApplyPhoneRules();

            RuleFor(user => user.UserType)
                .IsInEnum().WithMessage("Invalid user type.");
        }
    }
}
