using AutoMapper;
using Qurbanet.Database;
using Qurbanet.Models.DTOs.CuttingEvent;
using Qurbanet.Models.Entities;
using Qurbanet.Services.Interfaces;
using Qurbanet.Helpers;

namespace Qurbanet.Services
{
    public class CuttingEventService : ICuttingEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CuttingEventService> _logger;

        public CuttingEventService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CuttingEventService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<CuttingEventListDto>> GetAllByAnimalAsync(int animalId)
        {
            var repo = _unitOfWork.Repository<CuttingEvent>();
            var list = await repo.FindAsync(c => c.AnimalId == animalId);
            return _mapper.Map<List<CuttingEventListDto>>(list);
        }

        public async Task<CuttingEventDetailsDto> GetByIdAsync(int id)
        {
            var repo = _unitOfWork.Repository<CuttingEvent>();
            var entity = await repo.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogWarning(Constants.CustomExceptions.NotFound.ToString());
                throw Constants.CustomExceptions.NotFoundWithId(id);
            }
            return _mapper.Map<CuttingEventDetailsDto>(entity);
        }

        public async Task CreateAsync(CreateCuttingEventDto dto)
        {
            var entity = _mapper.Map<CuttingEvent>(dto);
            await _unitOfWork.Repository<CuttingEvent>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateCuttingEventDto dto)
        {
            var entity = _mapper.Map<CuttingEvent>(dto);
            await _unitOfWork.Repository<CuttingEvent>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var repo = _unitOfWork.Repository<CuttingEvent>();
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
