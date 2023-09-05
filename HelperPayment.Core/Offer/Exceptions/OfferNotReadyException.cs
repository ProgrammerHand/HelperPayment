using HelperPayment.Core.Exceptions;

namespace HelperPayment.Core.Offer.Exceptions
{
    public class OfferNotReadyException : CustomException
    {
        public OfferNotReadyException() : base("Offer not ready")
        {
        }
    }
}
