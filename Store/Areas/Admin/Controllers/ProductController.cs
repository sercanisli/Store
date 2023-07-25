using Entities.DTOs;
using Entities.Models;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Services.Contracts;
using Store.Models;

namespace Store.Areas.Admin.Controllers
{
	[Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
	{
		private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public ActionResult Index([FromQuery]ProductRequestParameters productRequestParameters)
        {
            ViewData["Title"] = "Products";
            var products = _serviceManager.ProductService.GetAllProductsWithDetails(productRequestParameters);
            var pagination = new Pagination()
            {
                CurrentPage = productRequestParameters.PageNumber,
                ItemsPerPage = productRequestParameters.PageSize,
                TotalItems = _serviceManager.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel() //bu ifadenin kullanılabilmesi için product index sayfasında @model ProductListViewModel tanımlaması gerekir.
            {
                Products = products,
                Pagination = pagination
            });
        }
        [HttpGet]
        public ActionResult Create()
        {
            TempData["info"] = "Please fill the form";
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
                TempData["success"] = $"{productDtoForInsertion.ProductName} has been created";
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
