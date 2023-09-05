using HelperPayment.Core.Exceptions;

namespace HelperPayment.Core.Offer.Exceptions
{
    public class StorageLinkEmptyException : CustomException
    {
        public StorageLinkEmptyException() : base("Link to storage is empty")
        {

        }
    }
}
