using Entities.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Store.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = "Admin")]
	public class CategoryController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public CategoryController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var products = _serviceManager.CategoryService.GetAllCategories(false);
            return View(products);
		}

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CategoryDTOForInsertion categoryDtoForInsertion)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.CategoryService.CreateCategory(categoryDtoForInsertion);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _serviceManager.CategoryService.DeleteCategory(id);
            return RedirectToAction("Index");
        }
    }
}
