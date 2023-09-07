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
        private IConnection _connection;
        private IModel _channel;
        private readonly IInvoiceService _invoiceServ;

        public RabbitMqClient(IInvoiceService invoiceServ)
        {
            _invoiceServ = invoiceServ;
        }

        public void CreateChannel() 
        {
            var _factory = new ConnectionFactory()
            { HostName = "localhost" };
            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
        }

        public void CreateQueue(string name = "PaymentBus")
        {
            _channel.QueueDeclare(queue: name,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
        }

        public void DeleteChannel() 
        {
            _connection.Abort();
        }

        public void publishEvent(string data, string routingKey = "PaymentBus") 
        {
                var body = Encoding.UTF8.GetBytes(data);
                _channel.BasicPublish(exchange: "",
                    routingKey: routingKey,
                    basicProperties: null, body);
        }

        public void consumeEvent()
        {;
            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                byte[] body = ea.Body.ToArray();
                var bodyAsJsonText = Encoding.UTF8.GetString(body);
                var data = JsonSerializer.Deserialize<InvoiceCreationDto>(bodyAsJsonText);
                if (data is InvoiceCreationDto)
                    _invoiceServ.CreateInvoiceAsync(data);

            };
            _channel.BasicConsume(queue: "PaymentBus", autoAck: true, consumer: consumer);
        }
    }
}
