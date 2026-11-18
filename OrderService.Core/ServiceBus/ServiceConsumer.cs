using Azure.Messaging.ServiceBus;
using Microsoft.Extensions.DependencyInjection;
using OrderService.Core.CosumerModels;
using OrderService.Core.Entities;
using OrderService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OrderService.Core.ServiceBus
{
    public class ServiceConsumer :IServiceConsumer
    {
        private readonly ServiceBusClient _serviceBusClient;
        private readonly IServiceScopeFactory _scopeFactory;
        private ServiceBusProcessor? _processor;

        public ServiceConsumer(ServiceBusClient serviceBusClient, IServiceScopeFactory serviceScopeFactory)
        {

            _serviceBusClient = serviceBusClient;
            _scopeFactory = serviceScopeFactory;
        }


        public async Task Consume()
        {
            _processor = _serviceBusClient.CreateProcessor("order.create","OrderService");

            _processor.ProcessMessageAsync += ProcessMessageHandler;
            _processor.ProcessErrorAsync += ErrorHandler;

            await _processor.StartProcessingAsync();
        }

        private async Task ProcessMessageHandler(
         ProcessMessageEventArgs args)
        {
            try
            {
                var data = JsonSerializer.Deserialize<OrderMessage>(args.Message.Body);
                List<Item> items = data.Items;
                Order order = new Order()
                {
                    UserId = data.UserId,
                    OrdeId = data.OrderId
                };

                // _logger.LogInformation($"Order received: {order.OrdeId}, User: {order.UserId}, Items: {items.Count}");

                using var scope = _scopeFactory.CreateScope();

                var _orderRepository = scope.ServiceProvider
                    .GetRequiredService<IOrderRepository>();

                _orderRepository.AddOrder(order, items);

                await args.CompleteMessageAsync(args.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error processing message: {ex.Message}");
                await args.AbandonMessageAsync(args.Message);
            }
        }

        private Task ErrorHandler(
            ProcessErrorEventArgs args)
        {
            Console.WriteLine(args.Exception);

            return Task.CompletedTask;
        }
    }
}
