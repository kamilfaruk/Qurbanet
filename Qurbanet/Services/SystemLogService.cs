using AutoMapper;
using Qurbanet.Database;
using Qurbanet.Models.DTOs.SystemLog;
using Qurbanet.Models.Entities;
using Qurbanet.Services.Interfaces;
using Qurbanet.Helpers;

namespace Qurbanet.Services
{
    public class SystemLogService : ISystemLogService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<SystemLogService> _logger;

        public SystemLogService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SystemLogService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<SystemLogListDto>> GetAllAsync()
        {
            var repo = _unitOfWork.Repository<SystemLog>();
            var list = await repo.GetAllAsync();
            return _mapper.Map<List<SystemLogListDto>>(list);
        }

        public async Task<SystemLogDetailsDto> GetByIdAsync(int id)
        {
            var repo = _unitOfWork.Repository<SystemLog>();
            var entity = await repo.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogWarning(Constants.CustomExceptions.NotFound.ToString());
                throw Constants.CustomExceptions.NotFoundWithId(id);
            }
            return _mapper.Map<SystemLogDetailsDto>(entity);
        }

        public async Task CreateAsync(CreateSystemLogDto dto)
        {
            var entity = _mapper.Map<SystemLog>(dto);
            await _unitOfWork.Repository<SystemLog>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateSystemLogDto dto)
        {
            var entity = _mapper.Map<SystemLog>(dto);
            await _unitOfWork.Repository<SystemLog>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var repo = _unitOfWork.Repository<SystemLog>();
            var entity = await repo.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogWarning(Constants.CustomExceptions.NotFound.ToString());
                throw Constants.CustomExceptions.NotFoundWithId(id);
            }
            await repo.DeleteAsync(entity);
        }
    }
}
