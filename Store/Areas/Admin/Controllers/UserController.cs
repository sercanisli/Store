using Entities.DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var users = _serviceManager.AuthService.Users();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new UserDTOForCreation()
            {
                Roles = new HashSet<string>(_serviceManager.AuthService.Roles.Select(r=>r.Name).ToList())
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDTOForCreation userDtoForCreation)
        {
            var result = await _serviceManager.AuthService.CreateUser(userDtoForCreation);
            if (!result.Succeeded)
            {
                return View();

            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update([FromRoute(Name = "id")]string id)
        {
            var user = await _serviceManager.AuthService.GetOneUserForUpdate(id);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UserDTOForUpdate userDtoForUpdate)
        {
            if (ModelState.IsValid)
            {
                await _serviceManager.AuthService.Update(userDtoForUpdate);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
