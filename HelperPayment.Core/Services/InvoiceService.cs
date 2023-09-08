using Helper.Application.DTO;
using HelperPayment.Core.DTO;
using HelperPayment.Core.External;
using HelperPayment.Core.Models.Invoice;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace HelperPayment.Core.Services
{
    public sealed class InvoiceService : IInvoiceService
    {
        private readonly IClockCustom _clock;
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly IServiceProvider _serviceProvider;

        public InvoiceService(IClockCustom clock, IInvoiceRepository invoiceRepo, IServiceProvider serviceProvider)
        {
            _clock = clock;
            _invoiceRepo = invoiceRepo;
            _serviceProvider = serviceProvider;
        }

        public async Task CreateInvoiceAsync(InvoiceCreationDto dto)
        {
            var invoice = new Invoice(dto);
            await _invoiceRepo.AddAsync(invoice);
        }

        public async Task HonourInvoiceAsync(Guid InvoiceId)
        {
            var invoice = await _invoiceRepo.GetByIdAsync(InvoiceId);
            invoice.Paid = Models.Invoice.ValueObjects.PaymentStatus.paid;
            await _invoiceRepo.UpdateAsync(invoice);
            var client = new RabbitMqClient(_serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IInvoiceService>());
            await client.CreateChannel();
            await client.CreateQueue();
            var dto = new InvoicePayment() { OfferId = invoice.OfferId };
            var serialized = JsonSerializer.Serialize(dto);
            await client.PublishEvent(serialized);
            await client.DeleteChannel();
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
