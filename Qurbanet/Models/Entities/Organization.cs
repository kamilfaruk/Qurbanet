using Qurbanet.Models.Entities;
using System.Collections.Generic;

namespace Qurbanet.Models.Entities
{
    public class Organization : BaseModel
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public User User { get; set; } = null!;
        public ICollection<Animal> Animals { get; set; } = new List<Animal>();
    }
}
