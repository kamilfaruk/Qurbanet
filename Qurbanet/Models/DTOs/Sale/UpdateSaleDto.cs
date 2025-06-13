namespace Qurbanet.Models.DTOs.Sale
{
    public class UpdateSaleDto
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public int CustomerId { get; set; }
        public decimal SalePrice { get; set; }
        public decimal AmountPaid { get; set; }
        public string? Notes { get; set; }
    }
}
