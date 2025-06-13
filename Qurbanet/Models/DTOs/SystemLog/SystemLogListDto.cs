namespace Qurbanet.Models.DTOs.SystemLog
{
    public class SystemLogListDto
    {
        public int Id { get; set; }
        public string EntityType { get; set; } = null!;
        public int EntityId { get; set; }
        public string Action { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}
