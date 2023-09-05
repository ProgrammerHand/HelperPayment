using Helper.Application.Offer.Queries;
using HelperPayment.Application.Abstraction.Queries;
using HelperPayment.Application.DTO;
using HelperPayment.Infrastructure.DAL;
using HelperPayment.Infrastructure.DAL.Handlers;
using Microsoft.EntityFrameworkCore;

namespace Helper.Infrastructure.DAL.Handlers
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
