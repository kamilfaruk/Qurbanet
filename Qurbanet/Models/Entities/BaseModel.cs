using System.ComponentModel.DataAnnotations;

namespace Qurbanet.Models.Entities
{
    public class BaseModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public int CreateUserId { get; set; }
        public int UpdateUserId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
