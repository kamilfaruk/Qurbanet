namespace Qurbanet.Models.DTOs.Animal
{
    public class CreateAnimalDto
    {
        public int OrganizationId { get; set; }
        public string NameOrTag { get; set; } = null!;
        public string Species { get; set; } = null!;
        public string Breed { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public double WeightKg { get; set; }
        public decimal Price { get; set; }
        public string? Notes { get; set; }
    }
}
