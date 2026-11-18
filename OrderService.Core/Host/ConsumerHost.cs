
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OrderService.Core.ServiceBus;



namespace OrderService.Core.Host
{
    public class ConsumerHost: IHostedService
    {
        private readonly IServiceConsumer _serviceConsumer;
        private readonly IServiceScopeFactory _scopeFactory;
        public ConsumerHost(IServiceScopeFactory scopeFactory, IServiceConsumer serviceConsumer) 
        {
            _scopeFactory = scopeFactory;
            _serviceConsumer = serviceConsumer;
        }  
        public async Task StartAsync(CancellationToken cancellationToken)
        {
           
            await _serviceConsumer.Consume();
           
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }   
    }
}
