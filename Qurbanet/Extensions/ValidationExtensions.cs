using FluentValidation;
using Qurbanet.Models.Enums;

namespace Qurbanet.Extensions
{
    public static class ValidationExtensions
    {
        public static IRuleBuilderOptions<T, string> ApplyNameRules<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");
        }

        public static IRuleBuilderOptions<T, string> ApplyEmailRules<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.");
        }
                 
        public static IRuleBuilderOptions<T, string> ApplyPhoneRules<T>(this IRuleBuilder<T, string> ruleBuilder)
        {
            return ruleBuilder
                .Matches(@"^(\+?[1-9]\d{1,14}|0\d{10})$").WithMessage("Invalid phone number format.")
                .When(instance => !string.IsNullOrEmpty(instance?.ToString())); // Doğru tür kontrolü
        }

        public static IRuleBuilderOptions<T, UserType> ApplyUserTypeRules<T>(this IRuleBuilder<T, UserType> ruleBuilder)
        {
            return ruleBuilder
                .IsInEnum().WithMessage("Invalid user type.");
        }

    }
}
