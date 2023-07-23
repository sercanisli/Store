using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;

namespace Store.Controllers
{
    public class ProductController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public ProductController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index(ProductRequestParameters productRequestParameters)
        {
            var model = _serviceManager.ProductService.GetAllProductsWithDetails(productRequestParameters);
            return View(model);
        }
        public IActionResult GetById([FromRoute(Name = "id")]int id)
        {
            var model = _serviceManager.ProductService.GetById(id, false);
            return View(model);
        }
    }
}
