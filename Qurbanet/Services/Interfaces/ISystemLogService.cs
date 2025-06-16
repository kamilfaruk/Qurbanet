using Qurbanet.Models.DTOs.SystemLog;

namespace Qurbanet.Services.Interfaces
{
    public interface ISystemLogService
    {
        Task<List<SystemLogListDto>> GetAllAsync();
        Task<SystemLogDetailsDto> GetByIdAsync(int id);
        Task CreateAsync(CreateSystemLogDto dto);
        Task UpdateAsync(UpdateSystemLogDto dto);
        Task DeleteAsync(int id);
    }
}
