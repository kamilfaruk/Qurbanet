using FluentValidation;
using Qurbanet.Extensions;
using Qurbanet.Models.DTOs.Customer;

namespace Qurbanet.Validators.Customer
{
    public class CreateCustomerDtoValidator : AbstractValidator<CreateCustomerDto>
    {
        public CreateCustomerDtoValidator()
        {
            RuleFor(x => x.FullName).ApplyNameRules();
            RuleFor(x => x.PhoneNumber).NotEmpty();
        }
    }
}
