using HelperPayment.Core.DTO;
using HelperPayment.Core.Services;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HelperPayment.Core.External
{
    public class RabbitMqClient
    {
        private IConnection? _connection;
        private IModel? _channel;
        private readonly IInvoiceService _invoiceServ;

        public RabbitMqClient(IInvoiceService invoiceServ)
        {
            _invoiceServ = invoiceServ;
        }

        public async Task CreateChannel() 
        {
            var _factory = new ConnectionFactory()
            { 
                HostName = "localhost",
                DispatchConsumersAsync = true
            };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public async Task CreateQueue(string name = "PaymentBus")
        {
            _channel.QueueDeclare(queue: name,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
        }

        public async Task DeleteChannel() 
        {
            if(_connection.IsOpen)
                _connection.Abort();
        }

        public async Task PublishEvent(string data, string routingKey = "PaymentBus") 
        {
                var body = Encoding.UTF8.GetBytes(data);
                _channel.BasicPublish(exchange: "",
                    routingKey: routingKey,
                    basicProperties: null, body);
        }

        public async Task ConsumeEvent()
        {
            var consumer = new AsyncEventingBasicConsumer(_channel);
            await Task.Yield();
            consumer.Received += async(model, ea) =>
            {
                var stream = new MemoryStream(ea.Body.ToArray());
                var data = await JsonSerializer.DeserializeAsync<InvoiceCreationDto>(stream);
                if (data is InvoiceCreationDto)
                    await _invoiceServ.CreateInvoiceAsync(data);
            };
            _channel.BasicConsume(queue: "PaymentBus", autoAck: true, consumer: consumer);
        }
    }
}
