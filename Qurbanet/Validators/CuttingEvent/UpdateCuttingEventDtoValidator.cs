using FluentValidation;
using Qurbanet.Models.DTOs.CuttingEvent;

namespace Qurbanet.Validators.CuttingEvent
{
    public class UpdateCuttingEventDtoValidator : AbstractValidator<UpdateCuttingEventDto>
    {
        public UpdateCuttingEventDtoValidator()
        {
            RuleFor(x => x.Stage).IsInEnum();
            RuleFor(x => x.OrderNumber).GreaterThan(0);
        }
    }
}
