using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using System.Data;

namespace Store.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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

        public async Task<IActionResult> ResetPassword([FromRoute(Name = "id")] string id)
        {
            return View(new ResetPasswordDTO()
            {
                UserName = id //parametre ile aldığımız id ifadesini burada UserName'e aktarırız.
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDTO resetPasswordDto)
        {
            var result = await _serviceManager.AuthService.ResetPassword(resetPasswordDto);
            if (result != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteOneUser([FromForm]UserDTO userDto)
        {
            var result = await _serviceManager.AuthService.DeleteOneUser(userDto.UserName);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");  
            }
            return View();
        }
    }
}
