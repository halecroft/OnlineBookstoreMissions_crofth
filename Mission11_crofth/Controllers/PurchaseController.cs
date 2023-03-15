using Microsoft.AspNetCore.Mvc;
using Mission11_crofth.Models;

namespace Mission11_crofth.Controllers
{
    public class PurchaseController : Controller
    {
        public IActionResult Checkout()
        {
            return View(new Purchase());
        }
    }
}
