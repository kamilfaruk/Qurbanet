using AutoMapper;
using Qurbanet.Database;
using Qurbanet.Models.Entities;
using Qurbanet.Models.DTOs.Organization;
using Qurbanet.Services.Interfaces;
using System.Linq;
using Qurbanet.Helpers;

namespace Qurbanet.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<OrganizationService> _logger;

        public OrganizationService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<OrganizationService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<OrganizationListDto>> GetAllAsync()
        {
            var repo = _unitOfWork.Repository<Organization>();
            var orgs = await repo.GetAllAsync();
            return _mapper.Map<List<OrganizationListDto>>(orgs);
        }

        public async Task<OrganizationDetailsDto> GetByIdAsync(int id)
        {
            var repo = _unitOfWork.Repository<Organization>();
            var org = await repo.GetByIdAsync(id);
            if (org == null)
            {
                _logger.LogWarning(Constants.CustomExceptions.NotFound.ToString());
                throw Constants.CustomExceptions.NotFoundWithId(id);
            }
            return _mapper.Map<OrganizationDetailsDto>(org);
        }

        public async Task CreateAsync(CreateOrganizationDto dto)
        {
            var entity = _mapper.Map<Organization>(dto);
            await _unitOfWork.Repository<Organization>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateOrganizationDto dto)
        {
            var entity = _mapper.Map<Organization>(dto);
            await _unitOfWork.Repository<Organization>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var repo = _unitOfWork.Repository<Organization>();
            var entity = await repo.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogWarning(Constants.CustomExceptions.NotFound.ToString());
                throw Constants.CustomExceptions.NotFoundWithId(id);
            }
            await repo.DeleteAsync(entity);
        }

        public async Task<OrganizationProgressDto> GetProgressAsync(int id)
        {
            var evRepo = _unitOfWork.Repository<CuttingEvent>();
            var events = await evRepo.FindAsync(e => e.Animal.OrganizationId == id);

            var progress = new OrganizationProgressDto
            {
                CuttingOrder = events.Where(e => e.Stage == "Kesim" && e.EndTime == null).OrderBy(e => e.OrderNumber).FirstOrDefault()?.OrderNumber,
                SkinningOrder = events.Where(e => e.Stage == "DeriYüzme" && e.EndTime == null).OrderBy(e => e.OrderNumber).FirstOrDefault()?.OrderNumber,
                ChoppingOrder = events.Where(e => e.Stage == "Parçalama" && e.EndTime == null).OrderBy(e => e.OrderNumber).FirstOrDefault()?.OrderNumber,
                DeliveredCount = events.Count(e => e.Stage == "Teslim" && e.EndTime != null)
            };
            return progress;
        }
    }
}
