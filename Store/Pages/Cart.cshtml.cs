using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Services.Contracts;
using Store.Infrastructure.Extensions;

namespace Store.Pages
{
    public class CartModel : PageModel
    {
        private readonly IServiceManager _serviceManager;
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";

        public CartModel(IServiceManager serviceManager, Cart cartService) 
        {
            _serviceManager = serviceManager;
            Cart = cartService; 
        }
        
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }
        public IActionResult OnPost(int id, string returnUrl)
        {
            Product? product = _serviceManager.ProductService.GetById(id, false);
            if (product!=null)
            {
                Cart.AddItem(product,1);
            }

            return RedirectToPage(new {ReturnUrl=returnUrl});
        }
        public IActionResult OnPostRemove(int id, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl=>cl.Product.Id==id).Product);
            return Page();
        }
    }
}
