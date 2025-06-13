namespace Qurbanet.Models.DTOs.Organization
{
    public class OrganizationListDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public bool IsPaid { get; set; }
    }
}
