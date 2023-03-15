using Microsoft.AspNetCore.Mvc;
using Mission11_crofth.Models;
using System.Linq;

namespace Mission11_crofth.Components
{
    public class CategoriesViewComponent : ViewComponent
    {
        private IBookstoreRepository bookstoreRepository { get; set; }

        public CategoriesViewComponent(IBookstoreRepository temp)
        {
            bookstoreRepository = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["bookCategory"];

            var categories = bookstoreRepository.Books
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x => x);

            return View(categories);
        }
    }
}
