using HelperPayment.Core.Exceptions;

namespace HelperPayment.Core.Models.Offer.Exceptions
{
    public class InccorectPriceException : CustomException
    {
        public InccorectPriceException() : base("Price is <= 0")
        {
        }
    }
}
