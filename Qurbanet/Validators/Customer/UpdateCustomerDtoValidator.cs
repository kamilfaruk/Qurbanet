using FluentValidation;
using Qurbanet.Extensions;
using Qurbanet.Models.DTOs.Customer;

namespace Qurbanet.Validators.Customer
{
    public class UpdateCustomerDtoValidator : AbstractValidator<UpdateCustomerDto>
    {
        public UpdateCustomerDtoValidator()
        {
            RuleFor(x => x.FullName).ApplyNameRules();
            RuleFor(x => x.PhoneNumber).NotEmpty();
        }
    }
}
