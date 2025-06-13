using AutoMapper;
using Qurbanet.Database;
using Qurbanet.Models.DTOs.Payment;
using Qurbanet.Models.Entities;
using Qurbanet.Services.Interfaces;
using Qurbanet.Helpers;

namespace Qurbanet.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<PaymentService> _logger;

        public PaymentService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<PaymentService> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<PaymentListDto>> GetAllBySaleAsync(int saleId)
        {
            var repo = _unitOfWork.Repository<Payment>();
            var list = await repo.FindAsync(p => p.SaleId == saleId);
            return _mapper.Map<List<PaymentListDto>>(list);
        }

        public async Task<PaymentDetailsDto> GetByIdAsync(int id)
        {
            var repo = _unitOfWork.Repository<Payment>();
            var entity = await repo.GetByIdAsync(id);
            if (entity == null)
            {
                _logger.LogWarning(Constants.CustomExceptions.NotFound.ToString());
                throw Constants.CustomExceptions.NotFoundWithId(id);
            }
            return _mapper.Map<PaymentDetailsDto>(entity);
        }

        public async Task CreateAsync(CreatePaymentDto dto)
        {
            var entity = _mapper.Map<Payment>(dto);
            await _unitOfWork.Repository<Payment>().AddAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateAsync(UpdatePaymentDto dto)
        {
            var entity = _mapper.Map<Payment>(dto);
            await _unitOfWork.Repository<Payment>().UpdateAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var repo = _unitOfWork.Repository<Payment>();
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
