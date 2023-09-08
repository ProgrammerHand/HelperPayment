namespace HelperPayment.Core.Exceptions
{
    public class EmptyIdException : CustomException
    {
        public EmptyIdException() : base("Empty Id was given")
        {
        }
    }
}
