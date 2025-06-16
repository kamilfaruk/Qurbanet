using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qurbanet.Models.DTOs.Animal;
using Qurbanet.Services.Interfaces;
using Qurbanet.Models.Enums;

namespace Qurbanet.Controllers
{
    [Authorize]
    public class AnimalController : Controller
    {
        private readonly IAnimalService _service;

        public AnimalController(IAnimalService service)
        {
            _service = service;
        }

        public async Task<IActionResult> List(int organizationId)
        {
            var animals = await _service.GetAllByOrganizationAsync(organizationId);
            ViewBag.OrganizationId = organizationId;
            return View(animals);
        }

        public async Task<IActionResult> Details(int id)
        {
            var animal = await _service.GetByIdAsync(id);
            return View(animal);
        }

        [HttpGet]
        [Authorize(Roles = nameof(UserType.Organizer) + "," + nameof(UserType.Admin))]
        public IActionResult Create(int organizationId)
        {
            ViewBag.OrganizationId = organizationId;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = nameof(UserType.Organizer) + "," + nameof(UserType.Admin))]
        public async Task<IActionResult> Create(CreateAnimalDto dto)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.OrganizationId = dto.OrganizationId;
                return View(dto);
            }
            await _service.CreateAsync(dto);
            return RedirectToAction("List", new { organizationId = dto.OrganizationId });
        }
    }
}
