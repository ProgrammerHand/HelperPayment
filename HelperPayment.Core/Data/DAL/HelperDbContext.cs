using HelperPayment.Core.Data.DAL.Exceptions;
using HelperPayment.Core.External;
using HelperPayment.Core.Models.Invoice;
using Microsoft.EntityFrameworkCore;

namespace HelperPayment.Core.Data.DAL
{
    public class HelperDbContext : DbContext
    {
        private readonly IClockCustom _clock;
        public DbSet<Invoice> Invoices { get; set; }
        public HelperDbContext(DbContextOptions<HelperDbContext> options, IClockCustom clock) : base(options)
        {
            _clock = clock;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(new SoftDeleteInterceptor(_clock));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            CheckRowVersion();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void CheckRowVersion()
        {
            ChangeTracker.DetectChanges();
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is IRowVersionControl && entry.State is not EntityState.Added)
                {
                    var property = entry.Property("RowVersion");
                    if (property.OriginalValue.Equals(property.CurrentValue))
                        throw new WrongRowVersionException();
                }
            }

        }
    }
}
