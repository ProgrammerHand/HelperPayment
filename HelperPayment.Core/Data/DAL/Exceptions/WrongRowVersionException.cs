using HelperPayment.Core.Exceptions;

namespace HelperPayment.Core.Data.DAL.Exceptions
{
    public sealed class WrongRowVersionException : CustomException
    {
        public WrongRowVersionException() : base("Given RowVersion expired")
        {
        }
    }
}
