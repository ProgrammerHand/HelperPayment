using HelperPayment.Core.Exceptions;

namespace HelperPayment.Core.Offer.Exceptions
{
    public class OfferAlredyVerifiedException : CustomException
    {
        public OfferAlredyVerifiedException() : base("Offer already verified")
        {

        }
    }
}
