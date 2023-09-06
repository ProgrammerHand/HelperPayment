using HelperPayment.Core.Exceptions;

namespace HelperPayment.Core.Models.Offer.Exceptions
{
    public class PaymentDateTooLateException : CustomException
    {
        public PaymentDateTooLateException() : base("Given date less than 5 days before realistation date")
        {
        }
    }
}
