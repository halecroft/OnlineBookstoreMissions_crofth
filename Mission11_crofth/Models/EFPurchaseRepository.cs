using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Mission11_crofth.Models
{
    public class EFPurchaseRepository : IPurchaseRepository
    {
        private BookstoreContext _context;

        public EFPurchaseRepository(BookstoreContext bookstoreContext)
        {
            _context = bookstoreContext;
        }

        public IQueryable<Purchase> Purchases => _context.Purchases.Include(x => x.Lines).ThenInclude(x => x.Book);

        public void SavePurchase(Purchase purchase)
        {
            _context.AttachRange(purchase.Lines.Select(x => x.Book));

            if (purchase.PurchaseId == 0)
            {
                _context.Purchases.Add(purchase);
            }

            _context.SaveChanges();
        }
    }
}
