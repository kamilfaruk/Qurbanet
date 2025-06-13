namespace Qurbanet.Models.Entities
{
    public class Payment : BaseModel
    {
        public int SaleId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;
        public string? Note { get; set; }

        public Sale Sale { get; set; } = null!;
    }
}
