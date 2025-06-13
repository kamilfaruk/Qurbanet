using AutoMapper;
using Qurbanet.Database;
using Qurbanet.Models.DTOs.Customer;
using Qurbanet.Models.Entities;
using Qurbanet.Services.Interfaces;
using Qurbanet.Helpers;

namespace Qurbanet.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerService> _logger;

        public CustomerService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomerService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<CustomerListDto>> GetAllAsync()
        {
            var repo = _unitOfWork.Repository<Customer>();
            var list = await repo.GetAllAsync();
            return _mapper.Map<List<CustomerListDto>>(list);
        }

        public async Task<CustomerDetailsDto> GetByIdAsync(int id)
        {
            var repo = _unitOfWork.Repository<Customer>();
            var entity = await repo.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogWarning(Constants.CustomExceptions.NotFound.ToString());
                throw Constants.CustomExceptions.NotFoundWithId(id);
            }
            return _mapper.Map<CustomerDetailsDto>(entity);
        }

        public async Task CreateAsync(CreateCustomerDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);
            await _unitOfWork.Repository<Customer>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdateCustomerDto dto)
        {
            var entity = _mapper.Map<Customer>(dto);
            await _unitOfWork.Repository<Customer>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var repo = _unitOfWork.Repository<Customer>();
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
