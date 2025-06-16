namespace Qurbanet.Models.DTOs.Organization
{
    public class OrganizationFinancialSummaryDto
    {
        public int TotalAnimals { get; set; }
        public int SoldAnimals { get; set; }
        public decimal TotalDue { get; set; }
        public decimal TotalPaid { get; set; }
        public decimal RemainingAmount => TotalDue - TotalPaid;
    }
}
