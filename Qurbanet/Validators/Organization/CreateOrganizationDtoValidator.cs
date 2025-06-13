using FluentValidation;
using Qurbanet.Extensions;
using Qurbanet.Models.DTOs.Organization;

namespace Qurbanet.Validators.Organization
{
    public class CreateOrganizationDtoValidator : AbstractValidator<CreateOrganizationDto>
    {
        public CreateOrganizationDtoValidator()
        {
            RuleFor(x => x.Name).ApplyNameRules();
            RuleFor(x => x.Year).GreaterThan(2000);
            RuleFor(x => x.StartDate).LessThan(x => x.EndDate);
        }
    }
}
