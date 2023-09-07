namespace HelperPayment.Core.Models.Invoice
{
    public class Invoice
    {
        public InvoiceId Id { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Price { get; set; }
        public bool Proforma { get; set; } = true;
        public byte[] RowVersion { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Invoice()
        {

        }

        public Invoice(DateTime paymentDate, double price)
        {
            Id = Guid.NewGuid();
            PaymentDate = paymentDate;
            Price = price;
        }
    }
}
