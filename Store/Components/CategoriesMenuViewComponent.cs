using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Store.Components
{
    public class CategoriesMenuViewComponent : ViewComponent
    {
        private readonly IServiceManager _serviceManager;

        public CategoriesMenuViewComponent(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IViewComponentResult Invoke() //render edilmesini istediğim için bu dönüş türünü seçiyorum.
        {
            var categories = _serviceManager.CategoryService.GetAllCategories(false);
            return View(categories); //bu yapıyı kullandığımızda bunun View dosyasını
            ///Views/[controller]/Components/[ViewComponent]/Default.cshtl yolunu kullanarak eklememiz gerekiyor.
        }
    }
}
