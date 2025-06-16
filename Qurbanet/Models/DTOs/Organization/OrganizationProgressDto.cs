namespace Qurbanet.Models.DTOs.Organization
{
    public class OrganizationProgressDto
    {
        public int? CuttingOrder { get; set; }
        public int? SkinningOrder { get; set; }
        public int? ChoppingOrder { get; set; }
        public int DeliveredCount { get; set; }
    }
}
