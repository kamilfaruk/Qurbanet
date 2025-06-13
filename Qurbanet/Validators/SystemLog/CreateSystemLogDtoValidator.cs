using FluentValidation;
using Qurbanet.Models.DTOs.SystemLog;

namespace Qurbanet.Validators.SystemLog
{
    public class CreateSystemLogDtoValidator : AbstractValidator<CreateSystemLogDto>
    {
        public CreateSystemLogDtoValidator()
        {
            RuleFor(x => x.EntityType).NotEmpty();
            RuleFor(x => x.Action).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
        }
    }
}
