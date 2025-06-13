using AutoMapper;
using Qurbanet.Models.DTOs.CuttingEvent;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Mappers
{
    public class CuttingEventProfile : Profile
    {
        public CuttingEventProfile()
        {
            CreateMap<CuttingEvent, CuttingEventListDto>();
            CreateMap<CuttingEvent, CuttingEventDetailsDto>();
            CreateMap<CreateCuttingEventDto, CuttingEvent>();
            CreateMap<UpdateCuttingEventDto, CuttingEvent>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
