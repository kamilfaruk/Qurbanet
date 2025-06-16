using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qurbanet.Models.DTOs.Customer;
using Qurbanet.Services.Interfaces;

namespace Qurbanet.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _service;

        public CustomerController(ICustomerService service)
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
            var customer = await _service.GetByIdAsync(id);
            return View(customer);
        }

        [HttpGet]
        [Authorize(Roles = "Organizer,Admin")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Organizer,Admin")]
        public async Task<IActionResult> Create(CreateCustomerDto dto)
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
