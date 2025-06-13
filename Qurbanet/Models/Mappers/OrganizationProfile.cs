using AutoMapper;
using Qurbanet.Models.DTOs.Organization;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Mappers
{
    public class OrganizationProfile : Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Organization, OrganizationListDto>();
            CreateMap<Organization, OrganizationDetailsDto>();
            CreateMap<CreateOrganizationDto, Organization>();
            CreateMap<UpdateOrganizationDto, Organization>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
