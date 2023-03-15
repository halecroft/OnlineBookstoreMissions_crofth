using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Mission11_crofth.Infrastructure;
using Mission11_crofth.Models;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Mission11_crofth.Pages
{
    public class PurchaseModel : PageModel
    {
        private IBookstoreRepository bookstoreRepository { get; set; }

        public Cart cart { get; set; }

        public PurchaseModel (IBookstoreRepository temp, Cart c)
        {
            bookstoreRepository = temp;
            cart = c;
        }

        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int bookId, string returnUrl)
        {
            Book b = bookstoreRepository.Books.FirstOrDefault(x => x.BookId == bookId);

            cart.AddItem(b, 1);

            return RedirectToPage(new {ReturnUrl = returnUrl});
        }

        public IActionResult OnPostRemove(int bookId, string returnUrl)
        {
            cart.RemoveItem(cart.Items.First(x => x.Book.BookId == bookId).Book);

            return RedirectToPage(new {ReturnUrl = returnUrl});
        }
    }
}
