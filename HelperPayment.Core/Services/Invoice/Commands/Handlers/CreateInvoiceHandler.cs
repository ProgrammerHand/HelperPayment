using HelperPayment.Core.Abstraction.Commands;
using HelperPayment.Core.External;
using HelperPayment.Core.Models.Invoice;
using HelperPayment.Core.Models.Offer;
using HelperPayment.Core.Services.Invoice.Commands;
using RabbitMQ.Client;
using System.Text;

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
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "PaymentBus",
                    durable: false,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null);

                var body = Encoding.UTF8.GetBytes(offer.Id.Value.ToString());

                channel.BasicPublish(exchange: "",
                    routingKey: "PaymentBus",
                    basicProperties: null, body);
            }
        }
    }
}
