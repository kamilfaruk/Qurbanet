namespace Qurbanet.Models.Entities
{
    public class Animal : BaseModel
    {
        public int OrganizationId { get; set; }
        public string NameOrTag { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string Breed { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public double WeightKg { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = "Available";
        public string? Notes { get; set; }

        public Organization Organization { get; set; } = null!;
        public Sale? Sale { get; set; }
        public ICollection<CuttingEvent> CuttingEvents { get; set; } = new List<CuttingEvent>();
    }
}
