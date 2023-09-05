namespace HelperPayment.Core.Invoice
{
    public interface IInvoiceRepository
    {
        Task AddAsync(Invoice invoice);
        Task UpdateAsync(Invoice invoice);
        Task<Invoice> GetByIdAsync(InvoiceId id);
    }
}
