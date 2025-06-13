namespace Qurbanet.Models.DTOs.Payment
{
    public class UpdatePaymentDto
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public decimal Amount { get; set; }
        public string? Note { get; set; }
    }
}
