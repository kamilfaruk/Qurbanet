namespace Qurbanet.Models.DTOs.Organization
{
    public class CreateOrganizationDto
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public bool IsPaid { get; set; } = false;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
