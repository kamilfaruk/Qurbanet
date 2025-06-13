namespace Qurbanet.Models.Entities
{
    public class Customer : BaseModel
    {
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
        public string? Notes { get; set; }

        public ICollection<Sale> Sales { get; set; } = new List<Sale>();
    }
}
