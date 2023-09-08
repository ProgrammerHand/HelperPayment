using HelperPayment.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelperPayment.Core.External
{
    public class BackgroundRabbitMQ : BackgroundService
    {
        private readonly RabbitMqClient _client;

        public BackgroundRabbitMQ(IServiceProvider serviceProvider)
        {
            _client = new RabbitMqClient(serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IInvoiceService>());
        }

        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            await _client.CreateChannel();
            await _client.CreateQueue("OfferBus");
            while (true)
            {
                await _client.ConsumeEvent();
                await Task.Yield();
            }
        }
    }
}
