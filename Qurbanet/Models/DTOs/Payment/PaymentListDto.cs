namespace Qurbanet.Models.DTOs.Payment
{
    public class PaymentListDto
    {
        public int Id { get; set; }
        public int SaleId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
