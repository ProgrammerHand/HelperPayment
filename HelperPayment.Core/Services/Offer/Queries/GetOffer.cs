using HelperPayment.Core.Abstraction.Queries;
using HelperPayment.Core.DTO;

namespace HelperPayment.Core.Services.Offer.Queries
{
    public class GetOffer : IQuery<OfferDto>
    {
        public Guid Id { get; private set; }

        public GetOffer(Guid id)
        {
            Id = id;
        }
    }
}