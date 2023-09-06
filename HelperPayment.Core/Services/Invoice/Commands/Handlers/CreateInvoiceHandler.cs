using HelperPayment.Core.Abstraction.Commands;
using HelperPayment.Core.External;
using HelperPayment.Core.Models.Invoice;
using HelperPayment.Core.Models.Offer;
using HelperPayment.Core.Services.Invoice.Commands;

namespace HelperPayment.Core.Services.Invoice.Commands.Handlers
{
    public sealed class CreateInvoiceHandler : ICommandHandler<CreateInvoice>
    {
        private readonly IClockCustom _clock;
        private readonly IOfferRepository _offerRepo;
        private readonly IInvoiceRepository _invoiceRepo;

        public CreateInvoiceHandler(IClockCustom clock, IOfferRepository offerRepo, IInvoiceRepository invoiceRepo)
        {
            _clock = clock;
            _offerRepo = offerRepo;
            _invoiceRepo = invoiceRepo;
        }

        public async Task HandleAsync(CreateInvoice command)
        {
            var offer = await _offerRepo.GetByIdAsync(command.offerId);
            var invoice = Models.Invoice.Invoice.CreateInvoice(offer);
            await _invoiceRepo.AddAsync(invoice);
        }
    }
}
