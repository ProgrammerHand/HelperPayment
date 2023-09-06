using HelperPayment.Core.Migrations;
using HelperPayment.Core.Models.Invoice;
using Microsoft.EntityFrameworkCore;

namespace HelperPayment.Core.Data.DAL.Repositories
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly HelperDbContext _context;
        public InvoiceRepository(HelperDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<Invoice> GetByIdAsync(InvoiceId id)
        {
            return await _context.Invoices.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task AddAsync(Invoice invoice)
        {
            await _context.Invoices.AddAsync(invoice);
            await Save();
        }

        public async Task UpdateAsync(Invoice invoice)
        {
            _context.Invoices.Update(invoice);
            await Save();
        }

        private async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
