using Qurbanet.Models.DTOs.Sale;

namespace Qurbanet.Services.Interfaces
{
    public interface ISaleService
    {
        Task<List<SaleListDto>> GetAllAsync();
        Task<SaleDetailsDto> GetByIdAsync(int id);
        Task CreateAsync(CreateSaleDto dto);
        Task UpdateAsync(UpdateSaleDto dto);
        Task DeleteAsync(int id);
    }
}
