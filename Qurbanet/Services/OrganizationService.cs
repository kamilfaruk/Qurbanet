using AutoMapper;
using Qurbanet.Database;
using Qurbanet.Models.Entities;
using Qurbanet.Models.DTOs.Organization;
using Qurbanet.Services.Interfaces;
using System.Linq;
using System.Collections.Generic;
using Qurbanet.Helpers;
using Qurbanet.Services.Common;

namespace Qurbanet.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<OrganizationService> _logger;
        private readonly ICurrentUserService _currentUserService;

        public OrganizationService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<OrganizationService> logger, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
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
                CuttingOrder = events.Where(e => e.Stage == Models.Enums.Stage.Kesim && e.EndTime == null)
                                      .OrderBy(e => e.OrderNumber)
                                      .FirstOrDefault()?.OrderNumber,
                SkinningOrder = events.Where(e => e.Stage == Models.Enums.Stage.DeriYuzme && e.EndTime == null)
                                       .OrderBy(e => e.OrderNumber)
                                       .FirstOrDefault()?.OrderNumber,
                ChoppingOrder = events.Where(e => e.Stage == Models.Enums.Stage.Parcalama && e.EndTime == null)
                                       .OrderBy(e => e.OrderNumber)
                                       .FirstOrDefault()?.OrderNumber,
                DeliveredCount = events.Count(e => e.Stage == Models.Enums.Stage.Teslim && e.EndTime != null)
            };
            return progress;
        }

        public async Task<OrganizationFinancialSummaryDto> GetFinancialSummaryAsync(int id)
        {
            var animalRepo = _unitOfWork.Repository<Animal>();
            var saleRepo = _unitOfWork.Repository<Sale>();

            var animals = await animalRepo.FindAsync(a => a.OrganizationId == id);
            var animalIds = animals.Select(a => a.Id).ToList();
            var sales = await saleRepo.FindAsync(s => animalIds.Contains(s.AnimalId));

            var totalAnimals = animals.Count();
            var soldAnimals = sales.Count();
            var totalDue = sales.Sum(s => s.SalePrice);
            var totalPaid = sales.Sum(s => s.AmountPaid);

            return new OrganizationFinancialSummaryDto
            {
                TotalAnimals = totalAnimals,
                SoldAnimals = soldAnimals,
                TotalDue = totalDue,
                TotalPaid = totalPaid
            };
        }

        public async Task<List<OrganizationListDto>> GetDashboardOrganizationsAsync()
        {
            var repo = _unitOfWork.Repository<Organization>();
            IEnumerable<Organization> orgs;

            var userId = _currentUserService.UserId;
            if (userId == null)
            {
                orgs = await repo.FindAsync(o => o.Name.Contains("Demo"));
                orgs = orgs.Take(1);
            }
            else
            {
                var user = await _unitOfWork.Repository<User>().GetByIdAsync(userId.Value);
                if (user == null)
                {
                    orgs = new List<Organization>();
                }
                else if (user.UserType == Models.Enums.UserType.Admin)
                {
                    orgs = await repo.GetAllAsync();
                }
                else if (user.UserType == Models.Enums.UserType.Organizer)
                {
                    orgs = await repo.FindAsync(o => o.UserId == userId.Value);
                }
                else
                {
                    orgs = await repo.FindAsync(o => o.Name.Contains("Demo"));
                    orgs = orgs.Take(1);
                }
            }

            return _mapper.Map<List<OrganizationListDto>>(orgs.ToList());
        }
    }
}
