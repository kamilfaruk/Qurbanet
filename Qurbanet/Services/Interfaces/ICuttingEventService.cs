using Qurbanet.Models.DTOs.CuttingEvent;

namespace Qurbanet.Services.Interfaces
{
    public interface ICuttingEventService
    {
        Task<List<CuttingEventListDto>> GetAllByAnimalAsync(int animalId);
        Task<CuttingEventDetailsDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCuttingEventDto dto);
        Task UpdateAsync(UpdateCuttingEventDto dto);
        Task DeleteAsync(int id);
    }
}
