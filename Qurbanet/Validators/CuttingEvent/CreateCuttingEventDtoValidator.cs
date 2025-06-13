using FluentValidation;
using Qurbanet.Models.DTOs.CuttingEvent;

namespace Qurbanet.Validators.CuttingEvent
{
    public class CreateCuttingEventDtoValidator : AbstractValidator<CreateCuttingEventDto>
    {
        public CreateCuttingEventDtoValidator()
        {
            RuleFor(x => x.Stage).NotEmpty();
            RuleFor(x => x.OrderNumber).GreaterThan(0);
        }
    }
}
