using HelperPayment.Core.Data.DAL;
using HelperPayment.Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperPayment.Core.External
{
    public class BackgroundRabbitMQ : IHostedService
    {
        private readonly IInvoiceService _invoiceServ;
        private readonly RabbitMqClient client;

        public BackgroundRabbitMQ(IInvoiceService invoiceServ)
        {
            _invoiceServ = invoiceServ;
            client = new RabbitMqClient(_invoiceServ);
        }
        

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await Task.Yield();
            await client.CreateChannel();
            await client.CreateQueue();
            while (true)
            {
                await client.ConsumeEvent();
            }

        }
        public Task StopAsync(CancellationToken cancellationToken) => client.DeleteChannel();
    }
}
