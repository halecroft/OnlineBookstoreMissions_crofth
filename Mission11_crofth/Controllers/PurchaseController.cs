using Microsoft.AspNetCore.Mvc;
using Mission11_crofth.Models;
using System.Linq;

namespace Mission11_crofth.Controllers
{
    public class PurchaseController : Controller
    {
        private IPurchaseRepository _purchaseRepository { get; set; }
        private Cart cart { get; set; }

        public PurchaseController (IPurchaseRepository purchaseRepository, Cart c)
        {
            _purchaseRepository = purchaseRepository;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }

        [HttpPost]
        public IActionResult Checkout(Purchase purchase)
        {
            if (cart.Items.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty");
            }

            if (ModelState.IsValid)
            {
                purchase.Lines = cart.Items.ToArray();
                _purchaseRepository.SavePurchase(purchase);
                cart.ClearCart();

                return View();
            }
            else
            {
                return View();
            }
        }
    }
}
