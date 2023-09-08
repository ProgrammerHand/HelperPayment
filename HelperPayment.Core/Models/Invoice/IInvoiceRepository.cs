using HelperPayment.Core.DTO;

namespace HelperPayment.Core.Models.Invoice
{
    public interface IInvoiceRepository
    {
        Task AddAsync(Invoice invoice);
        Task UpdateAsync(Invoice invoice);
        Task<Invoice> GetByIdAsync(Guid invoiceId);
        Task<List<Invoice>> GetAll();
    }
}
