using HelperPayment.Core.Exceptions;

namespace HelperPayment.Core.Models.Offer.Exceptions
{
    public class EmptyIdException : CustomException
    {
        public EmptyIdException() : base("Empty Id was given")
        {
        }
    }
}
