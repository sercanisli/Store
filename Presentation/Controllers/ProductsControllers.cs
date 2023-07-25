using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductsControllers : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public ProductsControllers(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            return Ok(_serviceManager.ProductService.GetAllProducts(false));
        }
    }
}
