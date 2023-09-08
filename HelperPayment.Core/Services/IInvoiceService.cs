using HelperPayment.Core.DTO;

namespace HelperPayment.Core.Services
{
    public interface IInvoiceService
    {
        Task CreateInvoiceAsync(InvoiceCreationDto dto);
        Task HonourInvoiceAsync(Guid InvoiceId);
        Task<List<InvoiceDto>> GetAll();
        Task<InvoiceDto> GetInvoiceById(Guid invoiceId);
    }
}
