using Qurbanet.Models.Enums;

namespace Qurbanet.Models.DTOs.User
{
    public class CreateUserDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public UserType UserType { get; set; }
    }
}
