using HelperPayment.Core.Exceptions;

namespace HelperPayment.Core.Offer.Exceptions
{
    public sealed class OfferDecisionAlredyGivenException : CustomException
    {
        public OfferDecisionAlredyGivenException() : base("Offer decision alredy given")
        {

        }
    }
}
