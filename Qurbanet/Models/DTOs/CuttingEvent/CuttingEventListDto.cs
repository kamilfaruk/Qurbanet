namespace Qurbanet.Models.DTOs.CuttingEvent
{
    public class CuttingEventListDto
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string Stage { get; set; } = null!;
        public int OrderNumber { get; set; }
    }
}
