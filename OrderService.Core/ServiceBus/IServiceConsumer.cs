

namespace OrderService.Core.ServiceBus
{
    public interface IServiceConsumer
    {
        Task Consume();
    }
}
