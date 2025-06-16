using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qurbanet.Models.DTOs.Organization;
using Qurbanet.Services.Interfaces;
using Qurbanet.Models.Enums;

namespace Qurbanet.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        public async Task<IActionResult> Progress(int id)
        {
            var progress = await _service.GetProgressAsync(id);
            return View(progress);
        }

        public async Task<IActionResult> Details(int id)
        {
            var org = await _service.GetByIdAsync(id);
            return View(org);
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
