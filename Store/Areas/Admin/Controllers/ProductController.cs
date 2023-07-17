using Entities.Models;
using Microsoft.AspNetCore.Mvc;
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
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm]Product product)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.ProductService.CreateProduct(product);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
