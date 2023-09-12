using HelperPayment.Core.DTO;
using HelperPayment.Core.External;
using HelperPayment.Core.Models.Invoice;
using HelperPayment.Shared.Events;
using System.Text.Json;

namespace HelperPayment.Core.Services
{
    public sealed class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly IRabbitMqClient client;

        public InvoiceService(IInvoiceRepository invoiceRepo, IRabbitMqClient rabbitMqClien)
        {
            _invoiceRepo = invoiceRepo;
            client = rabbitMqClien;
        }

        public async Task CreateInvoiceAsync(InvoiceCreatedEvent dto)
        {
            var invoice = new Invoice(dto);
            await _invoiceRepo.AddAsync(invoice);
        }

        public async Task HonourInvoiceAsync(Guid InvoiceId)
        {
            var invoice = await _invoiceRepo.GetByIdAsync(InvoiceId);
            invoice.Paid = Models.Invoice.ValueObjects.PaymentStatus.paid;
            await _invoiceRepo.UpdateAsync(invoice);
            var dto = new InvoicePaidEvent() { OfferId = invoice.OfferId };
            var serialized = JsonSerializer.Serialize(dto);
            await client.PublishEvent(serialized, "PaymentBus");
        }

        public async Task<List<InvoiceDto>> GetAll()
        {
            var entities = await _invoiceRepo.GetAll();
            var invoices = new List<InvoiceDto>();
            foreach (var entity in entities)
            {
                invoices.Add(entity.AsDto());
            }
            return invoices;
        }

        public async Task<InvoiceDto> GetInvoiceById(Guid invoiceId)
        {
            var entity = await _invoiceRepo.GetByIdAsync(invoiceId);
            return entity.AsDto();
        }
    }
}
