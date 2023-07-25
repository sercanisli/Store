using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Store.Components
{
    public class ShowcaseViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public ShowcaseViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke(string page = "default")
        {
            var products = _serviceManager.ProductService.GetShowcaseProducts(false);
            return page.Equals("default")
                ? View(products)
                : View("List", products);
        }
    }
}
