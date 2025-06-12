using Qurbanet.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace Qurbanet.Models.Entities
{
    public class User : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }
        public override string ToString()
        {
            return Name + " " + Surname;
        }
    }
}
