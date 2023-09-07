using HelperPayment.Core.DTO;
using HelperPayment.Core.External;
using HelperPayment.Core.Models.Invoice;

namespace HelperPayment.Core.Services
{
    public sealed class InvoiceService : IInvoiceService
    {
        private readonly IClockCustom _clock;
        private readonly IInvoiceRepository _invoiceRepo;

        public InvoiceService(IClockCustom clock, IInvoiceRepository invoiceRepo)
        {
            _clock = clock;
            _invoiceRepo = invoiceRepo;
        }

        public async Task CreateInvoiceAsync(InvoiceCreationDto dto)
        {
            var invoice = new Invoice(dto.PaymentDate, dto.Price);
            await _invoiceRepo.AddAsync(invoice);
        }
    }
}
