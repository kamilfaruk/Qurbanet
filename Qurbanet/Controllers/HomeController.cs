using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Qurbanet.Services.Interfaces;
using System.Threading.Tasks;

namespace Qurbanet.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOrganizationService _organizationService;

        public HomeController(ILogger<HomeController> logger, IOrganizationService organizationService)
        {
            _logger = logger;
            _organizationService = organizationService;
        }

        public async Task<IActionResult> Index()
        {
            var orgs = await _organizationService.GetDashboardOrganizationsAsync();
            return View(orgs);
        }

        [AllowAnonymous]
        public IActionResult Guide()
        {
            return View();
        }
    }
}
