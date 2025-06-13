namespace Qurbanet.Models.DTOs.Customer
{
    public class CustomerListDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
    }
}
