using Qurbanet.Models.DTOs.Customer;

namespace Qurbanet.Services.Interfaces
{
    public interface ICustomerService
    {
        Task<List<CustomerListDto>> GetAllAsync();
        Task<CustomerDetailsDto> GetByIdAsync(int id);
        Task CreateAsync(CreateCustomerDto dto);
        Task UpdateAsync(UpdateCustomerDto dto);
        Task DeleteAsync(int id);
    }
}
