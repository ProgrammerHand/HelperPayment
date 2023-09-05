using HelperPayment.Application.Abstraction.Commands;
using HelperPayment.Core.Offer;
using HelperPayment.Core.Utility;

namespace HelperPayment.Application.Invoice.Commands.Handlers
{
    public sealed class CreateInvoiceHandler : ICommandHandler<CreateInvoice>
    {
        private readonly IClockCustom _clock;
        private readonly IOfferRepository _offerRepo;

        public CreateInvoiceHandler(IClockCustom clock, IOfferRepository offerRepo)
        {
            _clock = clock;
            _offerRepo = offerRepo;
        }

        public async Task HandleAsync(CreateInvoice command)
        {
            var offer = await _offerRepo.GetByIdAsync(command.offerId);
            var invoice = Core.Invoice.Invoice.CreateInvoice(offer);
        }
    }
}
