using HelperPayment.Core.DTO;
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
        public async Task<Invoice> GetByIdAsync(Guid invoiceId)
        {
            return await _context.Invoices.FirstOrDefaultAsync(x => x.Id == invoiceId);
        }

        public async Task<List<Invoice>> GetAll() 
        {
            return await _context.Invoices.ToListAsync();  
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
