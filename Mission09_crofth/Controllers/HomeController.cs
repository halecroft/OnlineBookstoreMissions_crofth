using Microsoft.AspNetCore.Mvc;
using Mission09_crofth.Models;
using Mission09_crofth.Models.ViewModels;
using System.Linq;

namespace Mission09_crofth.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository _bookstoreRepository;

        public HomeController (IBookstoreRepository bookstoreRepository)
        {
            _bookstoreRepository = bookstoreRepository;
        }

        public IActionResult Index(int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = _bookstoreRepository.Books
                .OrderBy(book => book.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = _bookstoreRepository.Books.Count(),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }


    }
}
