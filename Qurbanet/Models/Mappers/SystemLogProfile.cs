using AutoMapper;
using Qurbanet.Models.DTOs.SystemLog;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Mappers
{
    public class SystemLogProfile : Profile
    {
        public SystemLogProfile()
        {
            CreateMap<SystemLog, SystemLogListDto>();
            CreateMap<SystemLog, SystemLogDetailsDto>();
            CreateMap<CreateSystemLogDto, SystemLog>();
            CreateMap<UpdateSystemLogDto, SystemLog>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
