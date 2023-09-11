using HelperPayment.Core.DTO;
using HelperPayment.Shared.Events;

namespace HelperPayment.Core.Services
{
    public interface IInvoiceService
    {
        Task CreateInvoiceAsync(InvoiceCreatedEvent dto);
        Task HonourInvoiceAsync(Guid InvoiceId);
        Task<List<InvoiceDto>> GetAll();
        Task<InvoiceDto> GetInvoiceById(Guid invoiceId);
    }
}
