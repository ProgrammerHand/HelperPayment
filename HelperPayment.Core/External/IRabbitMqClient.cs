using RabbitMQ.Client;

namespace HelperPayment.Core.External
{
    public interface IRabbitMqClient
    {
        public Task PublishEvent(string data, string routingKey = "PaymentBus");
        public Task ConsumeEvent(string queueName = "OfferBus");
    }
}
