namespace Qurbanet.Models.DTOs.SystemLog
{
    public class SystemLogDetailsDto
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string EntityType { get; set; } = null!;
        public int EntityId { get; set; }
        public string Action { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}
