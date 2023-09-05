using HelperPayment.Core.Invoice.ValueObjects;

namespace HelperPayment.Core.Invoice
{
    public class Invoice
    {
        public InvoiceId Id { get; private set; }
        public DateTime PaymentDate { get; private set; }
        public double Price { get; private set; }
        public byte[] RowVersion { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public DateTime ModifiedAt { get; private set; }
        public bool IsDeleted { get; private set; }
        public DateTime? DeletedAt { get; private set; }
        
        public Invoice()
        {
            
        }

    }
}
