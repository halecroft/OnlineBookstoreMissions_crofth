using System.Linq;

namespace Mission11_crofth.Models
{
    public interface IBookstoreRepository
    {
        IQueryable<Book> Books { get; }
    }
}
