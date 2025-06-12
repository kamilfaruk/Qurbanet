using FluentValidation;
using Qurbanet.Extensions;
using Qurbanet.Models.DTOs.User;

namespace Qurbanet.Validators.User
{
    public class CreateUserDtoValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserDtoValidator()
        {

            RuleFor(x => x.Name).ApplyNameRules();
  
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname is required.")
                .MaximumLength(50).WithMessage("Surname cannot exceed 50 characters.");

            RuleFor(x => x.Email).ApplyEmailRules();

            RuleFor(x => x.Phone).ApplyPhoneRules();

            RuleFor(user => user.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");

            RuleFor(user => user.UserType).ApplyUserTypeRules();
        }
    }
}
