using HelperPayment.Core.Abstraction.Queries;
using HelperPayment.Core.Data.DAL.Handlers;
using HelperPayment.Core.DTO;
using HelperPayment.Core.Models.Offer;
using HelperPayment.Core.Services.Offer.Queries;
using Microsoft.EntityFrameworkCore;

namespace HelperPayment.Core.Data.DAL.Handlers
{
    internal class GetOfferHandler : IQueryHandler<GetOffer, OfferDto>
    {
        private readonly HelperDbContext _context;

        public GetOfferHandler(HelperDbContext DbContext) => _context = DbContext;
        public async Task<OfferDto> HandleAsync(GetOffer query)
        {
            var offerId = new OfferId(query.Id);
            var offer = await _context.Offers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == offerId);
            return offer?.AsDto();
        }
    }
}
