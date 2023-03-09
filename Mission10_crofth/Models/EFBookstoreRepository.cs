using System.Linq;

namespace Mission10_crofth.Models
{
    public class EFBookstoreRepository : IBookstoreRepository
    {
        private BookstoreContext _context { get; set; }

        public EFBookstoreRepository(BookstoreContext context)
        {
            _context = context;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
