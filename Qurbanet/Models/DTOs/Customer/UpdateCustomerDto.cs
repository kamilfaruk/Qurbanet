namespace Qurbanet.Models.DTOs.Customer
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string? Email { get; set; }
        public string? Notes { get; set; }
    }
}
