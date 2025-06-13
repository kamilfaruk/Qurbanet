namespace Qurbanet.Models.DTOs.Animal
{
    public class AnimalDetailsDto
    {
        public int Id { get; set; }
        public string NameOrTag { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string Breed { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public double WeightKg { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; } = "Available";
        public string? Notes { get; set; }
    }
}
