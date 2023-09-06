using HelperPayment.Core.Exceptions;

namespace HelperPayment.Core.Models.Offer.Exceptions
{
    public class OfferNotReadyException : CustomException
    {
        public OfferNotReadyException() : base("Offer not ready")
        {
        }
    }
}
