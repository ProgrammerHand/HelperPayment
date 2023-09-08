using HelperPayment.Core.Models.Invoice.ValueObjects;

namespace HelperPayment.Core.DTO
{
    public sealed record InvoiceDto
    {
        public Guid Id { get; set; }
        public Guid OfferId { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime RealisationStart { get; set; }
        public DateTime RealisationEnd { get; set; }
        public double Price { get; set; }
        public bool Proforma { get; set; }
        public string Paid { get; set; }
        public string ClientEmail { get; set; }
        public string ClientName { get; set; }

    }
}
