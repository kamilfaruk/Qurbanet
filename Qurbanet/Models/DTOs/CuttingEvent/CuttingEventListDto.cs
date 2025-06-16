namespace Qurbanet.Models.DTOs.CuttingEvent
{
    public class CuttingEventListDto
    {
        public int Id { get; set; }
        public int AnimalId { get; set; }
        public Models.Enums.Stage Stage { get; set; }
        public int OrderNumber { get; set; }
    }
}
