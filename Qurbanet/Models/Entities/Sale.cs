namespace Qurbanet.Models.Entities
{
    public class Sale : BaseModel
    {
        public int AnimalId { get; set; }
        public int CustomerId { get; set; }

        public decimal SalePrice { get; set; }
        public decimal AmountPaid { get; set; }
        public decimal RemainingAmount => SalePrice - AmountPaid;

        public DateTime SaleDate { get; set; } = DateTime.UtcNow;
        public string? Notes { get; set; }

        public Animal Animal { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public ICollection<Payment> Payments { get; set; } = new List<Payment>();
    }
}
