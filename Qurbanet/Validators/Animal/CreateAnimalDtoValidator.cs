using FluentValidation;
using Qurbanet.Extensions;
using Qurbanet.Models.DTOs.Animal;

namespace Qurbanet.Validators.Animal
{
    public class CreateAnimalDtoValidator : AbstractValidator<CreateAnimalDto>
    {
        public CreateAnimalDtoValidator()
        {
            RuleFor(x => x.NameOrTag).ApplyNameRules();
            RuleFor(x => x.Species).NotEmpty();
            RuleFor(x => x.Breed).NotEmpty();
            RuleFor(x => x.Gender).NotEmpty();
        }
    }
}
