using AutoMapper;
using Qurbanet.Database;
using Qurbanet.Models.DTOs.Sale;
using Qurbanet.Models.Entities;
using Qurbanet.Services.Interfaces;
using Qurbanet.Helpers;

namespace Qurbanet.Services
{
    public class SaleService : ISaleService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<SaleService> _logger;

        public SaleService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<SaleService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<SaleListDto>> GetAllAsync()
        {
            var repo = _unitOfWork.Repository<Sale>();
            var list = await repo.GetAllAsync();
            return _mapper.Map<List<SaleListDto>>(list);
        }

        public async Task<SaleDetailsDto> GetByIdAsync(int id)
        {
            var repo = _unitOfWork.Repository<Sale>();
            var entity = await repo.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogWarning(Constants.CustomExceptions.NotFound.ToString());
                throw Constants.CustomExceptions.NotFoundWithId(id);
            }
            return _mapper.Map<SaleDetailsDto>(entity);
        }

        public async Task CreateAsync(CreateSaleDto dto)
        {
            var entity = _mapper.Map<Sale>(dto);
            await _unitOfWork.Repository<Sale>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateSaleDto dto)
        {
            var entity = _mapper.Map<Sale>(dto);
            await _unitOfWork.Repository<Sale>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var repo = _unitOfWork.Repository<Sale>();
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
