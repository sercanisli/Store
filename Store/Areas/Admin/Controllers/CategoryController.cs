using Microsoft.AspNetCore.Mvc;

namespace Store.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
