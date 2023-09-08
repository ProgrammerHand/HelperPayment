using HelperPayment.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HelperPayment.Core.External
{
    public class BackgroundRabbitMQ : IHostedService
    {
        private readonly RabbitMqClient client;

        public BackgroundRabbitMQ(IServiceProvider serviceProvider)
        {
            client = new RabbitMqClient(serviceProvider.CreateScope().ServiceProvider.GetRequiredService<IInvoiceService>());
        }
        

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await client.CreateChannel();
            await client.CreateQueue("OfferBus");
            while (true)
            {
                await client.ConsumeEvent();
                await Task.Yield();
            }
        }
        public Task StopAsync(CancellationToken cancellationToken) => client.DeleteChannel();
    }
}
