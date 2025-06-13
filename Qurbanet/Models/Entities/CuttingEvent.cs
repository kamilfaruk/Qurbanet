namespace Qurbanet.Models.Entities
{
    public class CuttingEvent : BaseModel
    {
        public int AnimalId { get; set; }
        public string Stage { get; set; } = null!; // Kesim, DeriYuzme, Parcalama, Teslim
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int OrderNumber { get; set; }

        public Animal Animal { get; set; } = null!;
    }
}
