using FluentValidation;
using Qurbanet.Models.DTOs.Payment;

namespace Qurbanet.Validators.Payment
{
    public class CreatePaymentDtoValidator : AbstractValidator<CreatePaymentDto>
    {
        public CreatePaymentDtoValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0);
        }
    }
}
