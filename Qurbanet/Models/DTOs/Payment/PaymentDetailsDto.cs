namespace Qurbanet.Models.DTOs.Payment
{
    public class PaymentDetailsDto
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? Note { get; set; }
    }
}
