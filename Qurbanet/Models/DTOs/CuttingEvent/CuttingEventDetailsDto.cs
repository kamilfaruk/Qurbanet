namespace Qurbanet.Models.DTOs.CuttingEvent
{
    public class CuttingEventDetailsDto
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public string Stage { get; set; } = null!;
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int OrderNumber { get; set; }
    }
}
