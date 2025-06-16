using AutoMapper;
using Qurbanet.Models.DTOs.Animal;
using Qurbanet.Models.Entities;

namespace Qurbanet.Models.Mappers
{
    public class AnimalProfile : Profile
    {
        public AnimalProfile()
        {
            CreateMap<Animal, AnimalListDto>();
            CreateMap<Animal, AnimalDetailsDto>();
            CreateMap<CreateAnimalDto, Animal>();
            CreateMap<UpdateAnimalDto, Animal>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
