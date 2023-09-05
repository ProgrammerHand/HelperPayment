using HelperPayment.Core.Offer;
using Microsoft.EntityFrameworkCore;

namespace HelperPayment.Infrastructure.DAL.Repositories
{
    public class OfferRepository : IOfferRepository
    {
        private readonly HelperDbContext _context;
        public OfferRepository(HelperDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<Offer> GetByIdAsync(OfferId id)
        {
            return await _context.Offers.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
