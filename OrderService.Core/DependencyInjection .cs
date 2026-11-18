
using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Core.Host;


namespace OrderService.Core
{
    public static class DependencyInjection
    { 
        public static IServiceCollection AddCore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(_ =>
            {
                return new ServiceBusClient(configuration["ServiceBus_Connection"]);
            });
         
            services.AddHostedService<ConsumerHost>();  
            return services;
        }
    }
}
