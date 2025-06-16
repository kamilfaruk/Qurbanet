using AutoMapper;
using Qurbanet.Models.DTOs.Customer;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Mappers
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerListDto>();
            CreateMap<Customer, CustomerDetailsDto>();
            CreateMap<CreateCustomerDto, Customer>();
            CreateMap<UpdateCustomerDto, Customer>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
