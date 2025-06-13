using FluentValidation;
using Qurbanet.Models.DTOs.SystemLog;

namespace Qurbanet.Validators.SystemLog
{
    public class UpdateSystemLogDtoValidator : AbstractValidator<UpdateSystemLogDto>
    {
        public UpdateSystemLogDtoValidator()
        {
            RuleFor(x => x.EntityType).NotEmpty();
            RuleFor(x => x.Action).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
