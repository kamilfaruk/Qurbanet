namespace Qurbanet.Models.DTOs.SystemLog
{
    public class CreateSystemLogDto
    {
        public int? UserId { get; set; }
        public string EntityType { get; set; } = null!;
        public int EntityId { get; set; }
        public string Action { get; set; } = null!;
        public string Description { get; set; } = null!;
    }
}
