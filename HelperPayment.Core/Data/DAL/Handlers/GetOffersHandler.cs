using HelperPayment.Core.Abstraction.Queries;
using HelperPayment.Core.DTO;
using HelperPayment.Core.Services.Offer.Queries;
using Microsoft.EntityFrameworkCore;

namespace HelperPayment.Core.Data.DAL.Handlers
{
    internal class GetOffersHandler : IQueryHandler<GetOffers, List<OfferDto>>
    {
        private readonly HelperDbContext _context;
        public GetOffersHandler(HelperDbContext DbContext) => _context = DbContext;
        public async Task<List<OfferDto>> HandleAsync(GetOffers querry)
        {
            var entities = await _context.Offers.ToListAsync();
            var offers = new List<OfferDto>();
            foreach (var entity in entities)
            {
                offers.Add(entity.AsDto());
            }
            return offers;
        }
    }
}
