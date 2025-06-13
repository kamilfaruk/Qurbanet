namespace Qurbanet.Models.Entities
{
    public class SystemLog : BaseModel
    {
        public int? UserId { get; set; }
        public string EntityType { get; set; } = null!;
        public int EntityId { get; set; }
        public string Action { get; set; } = null!; // Create, Update, Delete
        public string Description { get; set; } = null!;

        public User? User { get; set; }
    }
}
