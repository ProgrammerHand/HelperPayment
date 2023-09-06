using HelperPayment.Core.Models.Offer.Exceptions;

namespace HelperPayment.Core.Models.Invoice
{
    public class InvoiceId
    {
        public Guid Value { get; }

        public InvoiceId(Guid value)
        {
            if (value == Guid.Empty)
            {
                throw new EmptyIdException();
            }

            Value = value;
        }

        public static implicit operator Guid(InvoiceId data) => data.Value;

        public static implicit operator InvoiceId(Guid value) => new(value);
    }
}
