using Qurbanet.Models.DTOs.Payment;

namespace Qurbanet.Services.Interfaces
{
    public interface IPaymentService
    {
        Task<List<PaymentListDto>> GetAllBySaleAsync(int saleId);
        Task<PaymentDetailsDto> GetByIdAsync(int id);
        Task CreateAsync(CreatePaymentDto dto);
        Task UpdateAsync(UpdatePaymentDto dto);
        Task DeleteAsync(int id);
    }
}
