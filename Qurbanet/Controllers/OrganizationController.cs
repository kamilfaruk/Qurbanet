using Microsoft.AspNetCore.Mvc;
using Qurbanet.Models.DTOs.Organization;
using Qurbanet.Services.Interfaces;

namespace Qurbanet.Controllers
{
    public class OrganizationController : Controller
    {
        private readonly IOrganizationService _service;

        public OrganizationController(IOrganizationService service)
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
            var org = await _service.GetByIdAsync(id);
            return View(org);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateOrganizationDto dto)
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
