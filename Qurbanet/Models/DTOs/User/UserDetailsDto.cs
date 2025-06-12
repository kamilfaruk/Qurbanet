namespace Qurbanet.Models.DTOs.User
{
    public class UserDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string UserTypeName { get; set; } // Örneğin "Admin" veya "Teacher"
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
