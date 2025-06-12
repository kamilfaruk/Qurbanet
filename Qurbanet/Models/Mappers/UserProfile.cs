using AutoMapper;
using Qurbanet.Helpers;
using Qurbanet.Models.DTOs.User;
using Qurbanet.Models.Entities;
using Qurbanet.Models.Enums;

namespace Qurbanet.Models.Mappers
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Entity -> DTO (Detaylar için)
            CreateMap<User, UserDetailsDto>()
           .ForMember(dest => dest.UserTypeName, opt => opt.MapFrom(src => EnumHelper.GetDescription(src.UserType)));

            CreateMap<UserDetailsDto, User>()
                .ForMember(dest => dest.UserType, opt => opt.MapFrom(src => EnumHelper.GetEnumFromDescription<UserType>(src.UserTypeName)));

            // Entity -> DTO (Listeleme için)
            CreateMap<User, UserListDto>()
                .ForMember(dest => dest.UserTypeName, opt => opt.MapFrom(src => src.UserType.ToString()));

            // DTO -> Entity (Kullanıcı oluşturma için)
            CreateMap<CreateUserDto, User>();

            // DTO -> Entity (Kullanıcı güncelleme için)
            CreateMap<UpdateUserDto, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
            // Null değerleri güncelleme işlemlerinde atlama
        }
    }
}