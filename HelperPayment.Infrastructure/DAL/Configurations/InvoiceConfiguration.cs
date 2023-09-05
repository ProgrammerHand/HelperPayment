using HelperPayment.Core.Invoice;
using HelperPayment.Core.Offer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperPayment.Infrastructure.DAL.Configurations
{
    internal class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.ToTable("Invoices", "payments");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.RowVersion).IsRowVersion();
        }
    }
}
