using HelperPayment.Core.Exceptions;

namespace HelperPayment.Core.Models.Offer.Exceptions
{
    public class OfferAlredyVerifiedException : CustomException
    {
        public OfferAlredyVerifiedException() : base("Offer already verified")
        {

        }
    }
}
