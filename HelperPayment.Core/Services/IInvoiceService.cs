using HelperPayment.Core.DTO;

namespace HelperPayment.Core.Services
{
    public interface IInvoiceService
    {
        Task CreateInvoiceAsync(InvoiceCreationDto dto);
    }
}
