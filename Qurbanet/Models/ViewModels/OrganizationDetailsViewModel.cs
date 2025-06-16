using Qurbanet.Models.DTOs.Organization;

namespace Qurbanet.Models.ViewModels
{
    public class OrganizationDetailsViewModel
    {
        public OrganizationDetailsDto Organization { get; set; } = new();
        public OrganizationFinancialSummaryDto Summary { get; set; } = new();
    }
}
