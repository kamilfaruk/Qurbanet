namespace Qurbanet.Models.DTOs.Animal
{
    public class AnimalListDto
    {
        public int Id { get; set; }
        public string NameOrTag { get; set; } = null!;
        public string Species { get; set; } = null!;
        public decimal Price { get; set; }
        public string Status { get; set; } = "Available";
    }
}
