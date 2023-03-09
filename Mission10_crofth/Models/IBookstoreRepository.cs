using System.Linq;

namespace Mission10_crofth.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
