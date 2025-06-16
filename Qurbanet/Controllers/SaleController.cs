using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qurbanet.Models.DTOs.Sale;
using Qurbanet.Services.Interfaces;
using Qurbanet.Models.Enums;

namespace Qurbanet.Controllers
{
    [Authorize]
    public class SaleController : Controller
    {
        private readonly ISaleService _service;

        public SaleController(ISaleService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _service.GetAllAsync();
            return View(list);
        }

        public async Task<IActionResult> Details(int id)
        {
            var sale = await _service.GetByIdAsync(id);
            return View(sale);
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserType.Organizer) + "," + nameof(UserType.Admin))]
        public IActionResult Create()
        {
            return View();
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
