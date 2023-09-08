using HelperPayment.Core.DTO;
using HelperPayment.Core.External;
using HelperPayment.Core.Models.Invoice.ValueObjects;

namespace HelperPayment.Core.Models.Invoice
{
    public class Invoice : IDataAudit, ISoftDelete, IRowVersionControl
    {
        public InvoiceId Id { get; set; }
        public Guid OfferId { get; set; }
        public DateTime PaymentDate { get; set; }
        public DateTime RealisationStart { get; set; }
        public DateTime RealisationEnd { get; set; }
        public double Price { get; set; }
        public bool Proforma { get; set; } = true;
        public PaymentStatus Paid { get; set; } = PaymentStatus.awaits_payment;
        public string ClientsName { get; set; }
        public string ClientsEmail { get; set; }
        public byte[] RowVersion { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedAt { get; set; }

        public Invoice()
        {

        }

        public Invoice(InvoiceCreationDto dto)
        {
            Id = Guid.NewGuid();
            PaymentDate = dto.PaymentDate;
            Price = dto.Price;
            OfferId = dto.OfferId;
            RealisationStart = dto.RealisationStart;
            RealisationEnd = dto.RealisationEnd;
            ClientsName = dto.ClientName;
            ClientsEmail = dto.ClientEmail;
        }
    }
}
