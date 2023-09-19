using HelperPayment.Core.Services;
using HelperPayment.Shared.Events;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace HelperPayment.Core.External
{
    public class RabbitMqClient : IRabbitMqClient
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ConnectionFactory _factory;
        private static IConnection? _connection;

        public RabbitMqClient(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            _serviceProvider = serviceProvider;
            string adress = configuration.GetValue<string>("MessageBrockerAdress");
            if (adress.Contains("localhost"))
            {
                _factory = new ConnectionFactory()
                {
                    HostName = adress,
                    DispatchConsumersAsync = true
                };
            }
            else
            {
                _factory = new ConnectionFactory()
                {
                    Uri = new Uri(adress),
                    DispatchConsumersAsync = true
                };
            }
            if (_connection is null)
                _connection = _factory.CreateConnection();

        }

        internal async Task CreateQueue(IModel channel, string name = "PaymentBus")
        {
            channel.QueueDeclare(queue: name,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
        }

        public async Task PublishEvent(string data, string routingKey = "PaymentBus") 
        {
            using (var channel = _connection.CreateModel())
            {
                await CreateQueue(channel, routingKey);
                var body = Encoding.UTF8.GetBytes(data);
                channel.BasicPublish(exchange: "",
                                            routingKey: routingKey,
                                            basicProperties: null, body);
            }
        }

        public async Task ConsumeEvent(string queueName = "OfferBus" )
        {
            using (var channel = _connection.CreateModel())
            {
                await CreateQueue(channel, queueName);
                var consumer = new AsyncEventingBasicConsumer(channel);
                //await Task.Yield();
                consumer.Received += async (model, ea) =>
                {
                    var stream = new MemoryStream(ea.Body.ToArray());
                    InvoiceCreatedEvent data = await JsonSerializer.DeserializeAsync<InvoiceCreatedEvent>(stream);
                    if (data is InvoiceCreatedEvent)
                        using (var scope = _serviceProvider.CreateScope())
                            await scope.ServiceProvider.GetRequiredService<IInvoiceService>().CreateInvoiceAsync(data);
                };
                channel.BasicConsume(queue: queueName, autoAck: true, consumer: consumer);
                await Task.Delay(1);
            }
            //await Task.Delay(100);
        }
    }
}
