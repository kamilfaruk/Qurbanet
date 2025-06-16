using AutoMapper;
using Qurbanet.Models.DTOs.Payment;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Mappers
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            CreateMap<Payment, PaymentListDto>();
            CreateMap<Payment, PaymentDetailsDto>();
            CreateMap<CreatePaymentDto, Payment>();
            CreateMap<UpdatePaymentDto, Payment>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
