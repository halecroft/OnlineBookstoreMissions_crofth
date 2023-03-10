using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission10_crofth.Infrastructure;
using Mission10_crofth.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Mission10_crofth.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookstoreRepository bookstoreRepository { get; set; }

        public PurchaseModel (IBookstoreRepository temp)
        {
            bookstoreRepository = temp;
        }

        public Cart cart { get; set; }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = bookstoreRepository.Books.FirstOrDefault(x => x.BookId == bookId);

            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            cart.AddItem(b, 1);

            HttpContext.Session.SetJson("cart", cart);

            return RedirectToPage(new {ReturnUrl = returnUrl});
        }
    }
}
