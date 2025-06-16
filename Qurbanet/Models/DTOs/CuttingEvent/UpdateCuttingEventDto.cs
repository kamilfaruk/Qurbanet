namespace Qurbanet.Models.DTOs.CuttingEvent
{
    public class UpdateCuttingEventDto
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public Models.Enums.Stage Stage { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int OrderNumber { get; set; }
    }
}
