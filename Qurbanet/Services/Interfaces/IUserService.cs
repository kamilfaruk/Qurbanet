using Qurbanet.Models.DTOs.User;
using Qurbanet.Models.Entities;

namespace Qurbanet.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserListDto>> GetAllUsersAsync();
        Task<UserDetailsDto> GetUserByIdAsync(int id);
        Task CreateUserAsync(CreateUserDto user);
        Task UpdateUserAsync(UpdateUserDto user);
        Task DeleteUserAsync(int id);
    }
}
