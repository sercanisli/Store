using Entities.DTOs;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;

namespace Store.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ProductController : Controller
	{
		private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public ActionResult Index()
        {
            var model = _serviceManager.ProductService.GetAllProducts(false);
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Categories = GetCategorieSelectList();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm]ProductDTOForInsertion productDtoForInsertion, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images",file.FileName );
                using (var stream = new FileStream(path,FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDtoForInsertion.ImageUrl = String.Concat("/images/", file.FileName);
                _serviceManager.ProductService.CreateProduct(productDtoForInsertion);
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Update([FromRoute(Name = "id")] int id)
        {
            ViewBag.Categories = GetCategorieSelectList();
            var product = _serviceManager.ProductService.GetByIdForUpdate(id, false);
            return View(product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm]ProductDTOForUpdate productDtoForUpdate, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", file.FileName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
                productDtoForUpdate.ImageUrl = String.Concat("/images/", file.FileName);
                _serviceManager.ProductService.Update(productDtoForUpdate);
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")]int id)
        {
            _serviceManager.ProductService.DeleteProduct(id);
            return RedirectToAction("Index");
        }

        private SelectList GetCategorieSelectList()
        {
            return new SelectList(_serviceManager.CategoryService.GetAllCategories(false),
                "Id", "CategoryName", "1");
        }
    }
}
