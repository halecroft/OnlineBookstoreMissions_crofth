using System.Linq;

namespace Mission09_crofth.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
