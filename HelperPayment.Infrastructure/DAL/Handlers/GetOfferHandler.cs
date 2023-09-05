using Helper.Application.Offer.Queries;
using HelperPayment.Application.Abstraction.Queries;
using HelperPayment.Application.DTO;
using HelperPayment.Core.Offer;
using HelperPayment.Infrastructure.DAL;
using HelperPayment.Infrastructure.DAL.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Helper.Infrastructure.DAL.Handlers
{
    internal class GetOfferHandler : IQueryHandler<GetOffer, OfferDto>
    {
        private readonly HelperPaymentDbContext _context;

        public GetOfferHandler(HelperPaymentDbContext DbContext) => _context = DbContext;
        public async Task<OfferDto> HandleAsync(GetOffer query)
        {
            var offerId = new OfferId(query.Id);
            var offer = await _context.Offers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == offerId);
            return offer?.AsDto();
        }
    }
}
