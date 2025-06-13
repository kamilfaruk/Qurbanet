using FluentValidation;
using Qurbanet.Models.DTOs.Sale;

namespace Qurbanet.Validators.Sale
{
    public class UpdateSaleDtoValidator : AbstractValidator<UpdateSaleDto>
    {
        public UpdateSaleDtoValidator()
        {
            RuleFor(x => x.SalePrice).GreaterThan(0);
            RuleFor(x => x.AmountPaid).GreaterThanOrEqualTo(0);
        }
    }
}
