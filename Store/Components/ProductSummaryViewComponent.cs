using Microsoft.AspNetCore.Mvc;
using Repositories.Concrete.Context;
using Services.Contracts;

namespace Store.Components
{
    public class ProductSummaryViewComponent :ViewComponent
    {
        private readonly IServiceManager _serviceManager; 

        public ProductSummaryViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public string Invoke()
        {
            return _serviceManager.ProductService.GetAllProducts(false).Count().ToString();
        }
    }
}
