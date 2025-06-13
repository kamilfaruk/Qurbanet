using AutoMapper;
using Qurbanet.Database;
using Qurbanet.Models.Entities;
using Qurbanet.Models.DTOs.Animal;
using Qurbanet.Services.Interfaces;
using Qurbanet.Helpers;

namespace Qurbanet.Services
{
    public class AnimalService : IAnimalService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<AnimalService> _logger;

        public AnimalService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AnimalService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<AnimalListDto>> GetAllByOrganizationAsync(int organizationId)
        {
            var repo = _unitOfWork.Repository<Animal>();
            var list = await repo.FindAsync(a => a.OrganizationId == organizationId);
            return _mapper.Map<List<AnimalListDto>>(list);
        }

        public async Task<AnimalDetailsDto> GetByIdAsync(int id)
        {
            var repo = _unitOfWork.Repository<Animal>();
            var entity = await repo.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogWarning(Constants.CustomExceptions.NotFound.ToString());
                throw Constants.CustomExceptions.NotFoundWithId(id);
            }
            return _mapper.Map<AnimalDetailsDto>(entity);
        }

        public async Task CreateAsync(CreateAnimalDto dto)
        {
            var entity = _mapper.Map<Animal>(dto);
            await _unitOfWork.Repository<Animal>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateAnimalDto dto)
        {
            var entity = _mapper.Map<Animal>(dto);
            await _unitOfWork.Repository<Animal>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var repo = _unitOfWork.Repository<Animal>();
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
