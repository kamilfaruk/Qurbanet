namespace Qurbanet.Models.DTOs.Payment
{
    public class CreatePaymentDto
    {
        public int SaleId { get; set; }
        public decimal Amount { get; set; }
        public string? Note { get; set; }
    }
}
