using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Qurbanet.Helpers;
using Qurbanet.Models.DTOs.User;
using Qurbanet.Services.Interfaces;

namespace Qurbanet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService, ILogger<UserController> logger)
        {
            _userService = userService;
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            var users = await _userService.GetAllUsersAsync();
            return View(users);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userService.GetUserByIdAsync(id);
            return View(user);
        }

        // GET: User/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateUserDto createUserDto)
        {
            throw Constants.CustomExceptions.BadRequest;
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors).ToList();
                return View(createUserDto); // Hataları görmek için aynı sayfayı tekrar render edelim
            }
            await _userService.CreateUserAsync(createUserDto);
            return RedirectToAction("Index");
        }
    }
}