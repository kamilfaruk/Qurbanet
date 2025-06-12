using AutoMapper;
using Qurbanet.Database;
using Qurbanet.Helpers;
using Qurbanet.Models.DTOs.User;
using Qurbanet.Models.Entities;
using Qurbanet.Services.Interfaces;

namespace Qurbanet.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UserService> _logger;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<List<UserListDto>> GetAllUsersAsync()
        {
            var userRepository = _unitOfWork.Repository<User>();
            var users = await userRepository.GetAllAsync();
            if (users == null || !users.Any())
            {
                throw Constants.CustomExceptions.NotFound;
            }
            List<UserListDto> userListDtos = _mapper.Map<List<UserListDto>>(users);
            return userListDtos;
        }

        public async Task<UserDetailsDto> GetUserByIdAsync(int id)
        {
            var user = await _unitOfWork.Repository<User>().GetByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning(Constants.CustomExceptions.NotFound.ToString());
                throw Constants.CustomExceptions.NotFoundWithId(id);
            }
            UserDetailsDto userDetailsDto = _mapper.Map<UserDetailsDto>(user);
            return userDetailsDto;
        }

        public async Task CreateUserAsync(CreateUserDto createUserDto)
        {
            User user = _mapper.Map<User>(createUserDto);
            var userRepository = _unitOfWork.Repository<User>();
            await userRepository.AddAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        /*
         *TODO: ÖRNEK KOD - TRANSACTION
        // Bir kullanıcı oluşturma işlemi ve ona bir rol ekleme işlemini tek bir transaction içinde yapılışı
        public async Task<bool> CreateUserWithRolesAsync(User user, int roleId)
        {
            // Transaction başlat
            await _unitOfWork.BeginTransactionAsync(); 
            try
            {
                // Kullanıcıyı ekle
                await _unitOfWork.Repository<User>().AddAsync(user);
                await _unitOfWork.SaveChangesAsync();
                // Kullanıcıya rol ekle
                var userRole = new UserRole { UserId = user.Id, RoleId = roleId };
                await _unitOfWork.Repository<UserRole>().AddAsync(userRole);
                await _unitOfWork.SaveChangesAsync();
                // Transaction'ı tamamla
                await _unitOfWork.CommitTransactionAsync();
                return true;
            }
            catch
            {
                // Hata durumunda geri al
                await _unitOfWork.RollbackTransactionAsync();
                throw;
            }
        }
        */

        public async Task UpdateUserAsync(UpdateUserDto updateUserDto)
        {
            User user = _mapper.Map<User>(updateUserDto);
            var userRepository = _unitOfWork.Repository<User>();
            await userRepository.UpdateAsync(user);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var userRepository = _unitOfWork.Repository<User>();
            var user = await userRepository.GetByIdAsync(id);
            if (user == null)
            {
                _logger.LogWarning(Constants.CustomExceptions.NotFound.ToString());
                throw Constants.CustomExceptions.NotFoundWithId(id);
            }
            await userRepository.DeleteAsync(user);
        }
    }
}
