using HelperPayment.Core.Abstraction.Commands;
using HelperPayment.Core.Models.Offer;

namespace HelperPayment.Core.Services.Invoice.Commands
{
    public sealed record CreateInvoice(OfferId offerId) : ICommand;
}

