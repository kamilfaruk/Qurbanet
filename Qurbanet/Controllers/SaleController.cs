using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qurbanet.Models.DTOs.Sale;
using Qurbanet.Services.Interfaces;
using Qurbanet.Models.Enums;
using Qurbanet.Models.DTOs.Payment;

namespace Qurbanet.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private readonly ISaleService _service;
        private readonly IPaymentService _paymentService;

        public SaleController(ISaleService service, IPaymentService paymentService)
        {
            _service = service;
            _paymentService = paymentService;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var sale = await _service.GetByIdAsync(id);
            var payments = await _paymentService.GetAllBySaleAsync(id);
            ViewBag.Payments = payments;
            return View(sale);
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserType.Organizer) + "," + nameof(UserType.Admin))]
        public IActionResult Create(int animalId)
        {
            var dto = new CreateSaleDto { AnimalId = animalId };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = nameof(UserType.Organizer) + "," + nameof(UserType.Admin))]
        public async Task<IActionResult> Create(CreateSaleDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _service.CreateAsync(dto);
            return RedirectToAction("Index");
        }
    }
}
