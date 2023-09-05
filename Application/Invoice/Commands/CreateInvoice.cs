using HelperPayment.Application.Abstraction.Commands;
using HelperPayment.Core.Offer;

namespace HelperPayment.Application.Invoice.Commands
{
    public sealed record CreateInvoice(OfferId offerId) : ICommand;
}

