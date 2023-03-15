using System.Linq;

namespace Mission11_crofth.Models.ViewModels
{
    public class BooksViewModel
    {
        public IQueryable<Book> Books { get; set;}
        public PageInfo PageInfo { get; set;}
    }
}
