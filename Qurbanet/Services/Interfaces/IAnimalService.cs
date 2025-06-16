using Qurbanet.Models.DTOs.Animal;

namespace Qurbanet.Services.Interfaces
{
    public interface IAnimalService
    {
        Task<List<AnimalListDto>> GetAllByOrganizationAsync(int organizationId);
        Task<AnimalDetailsDto> GetByIdAsync(int id);
        Task CreateAsync(CreateAnimalDto dto);
        Task UpdateAsync(UpdateAnimalDto dto);
        Task DeleteAsync(int id);
    }
}
