using Entities.RequestParameters;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using Services.Contracts;
using Store.Models;

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
            var products = _serviceManager.ProductService.GetAllProductsWithDetails(productRequestParameters);
            var pagination = new Pagination()
            {
                CurrentPage = productRequestParameters.PageNumber,
                ItemsPerPage = productRequestParameters.PageSize,
                TotalItems = _serviceManager.ProductService.GetAllProducts(false).Count()
            };
            return View(new ProductListViewModel()
            {
                Products = products,
                Pagination = pagination
            });
        }
        public IActionResult GetById([FromRoute(Name = "id")]int id)
        {
            var model = _serviceManager.ProductService.GetById(id, false);
            return View(model);
        }
    }
}
