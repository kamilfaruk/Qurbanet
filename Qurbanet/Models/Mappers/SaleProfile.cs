using AutoMapper;
using Qurbanet.Models.DTOs.Sale;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Mappers
{
    public class SaleProfile : Profile
    {
        public SaleProfile()
        {
            CreateMap<Sale, SaleListDto>();
            CreateMap<Sale, SaleDetailsDto>();
            CreateMap<CreateSaleDto, Sale>();
            CreateMap<UpdateSaleDto, Sale>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
