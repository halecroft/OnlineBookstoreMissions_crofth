using Microsoft.AspNetCore.Mvc;
using Mission11_crofth.Models;
using Mission11_crofth.Models.ViewModels;
using System.Linq;

namespace Mission11_crofth.Controllers
{
    public class HomeController : Controller
    {
        private IBookstoreRepository _bookstoreRepository;

        public HomeController (IBookstoreRepository bookstoreRepository)
        {
            _bookstoreRepository = bookstoreRepository;
        }

        public IActionResult Index(string bookCategory, int pageNum = 1)
        {
            int pageSize = 10;

            var x = new BooksViewModel
            {
                Books = _bookstoreRepository.Books
                .Where(book => book.Category == bookCategory || bookCategory == null)
                .OrderBy(book => book.Title)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize),

                PageInfo = new PageInfo
                {
                    TotalNumBooks = 
                        (bookCategory == null 
                        ? _bookstoreRepository.Books.Count() 
                        : _bookstoreRepository.Books.Where(x => x.Category == bookCategory).Count()),
                    BooksPerPage = pageSize,
                    CurrentPage = pageNum
                }
            };

            return View(x);
        }


    }
}
