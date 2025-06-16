using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qurbanet.Models.DTOs.Payment;
using Qurbanet.Services.Interfaces;

namespace Qurbanet.Controllers
{
    [Authorize]
    public class PaymentController : Controller
    {
        private readonly IPaymentService _service;

        public PaymentController(IPaymentService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Create(int saleId)
        {
            var dto = new CreatePaymentDto { SaleId = saleId };
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreatePaymentDto dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            await _service.CreateAsync(dto);
            return RedirectToAction("Details", "Sale", new { id = dto.SaleId });
        }
    }
}
