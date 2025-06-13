using FluentValidation;
using Qurbanet.Models.DTOs.Payment;

namespace Qurbanet.Validators.Payment
{
    public class UpdatePaymentDtoValidator : AbstractValidator<UpdatePaymentDto>
    {
        public UpdatePaymentDtoValidator()
        {
            RuleFor(x => x.Amount).GreaterThan(0);
        }
    }
}
