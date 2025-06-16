using Qurbanet.Models.DTOs.Organization;

namespace Qurbanet.Services.Interfaces
{
    public interface IOrganizationService
    {
        Task<List<OrganizationListDto>> GetAllAsync();
        Task<OrganizationDetailsDto> GetByIdAsync(int id);
        Task CreateAsync(CreateOrganizationDto dto);
        Task UpdateAsync(UpdateOrganizationDto dto);
        Task DeleteAsync(int id);
        Task<OrganizationProgressDto> GetProgressAsync(int id);
        Task<OrganizationFinancialSummaryDto> GetFinancialSummaryAsync(int id);
        Task<List<OrganizationListDto>> GetDashboardOrganizationsAsync();
    }
}
