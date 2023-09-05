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
        
        private Invoice()
        {
            
        }

        private Invoice(Offer.Offer offer, InvoiceId id)
        {
            Id = id;
            PaymentDate = (DateTime)offer.PaymentDate;
            Price = offer.Price;

        }

        public static Invoice CreateInvoice(Offer.Offer offer) 
        {
            var id = Guid.NewGuid();
            return new Invoice(offer, id);
        }

    }
}
