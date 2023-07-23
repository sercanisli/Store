﻿using Microsoft.AspNetCore.Mvc;
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

        public IViewComponentResult Invoke()
        {
            var product = _serviceManager.ProductService.GetShowcaseProducts(false);
            return View(product);
        }
    }
}
