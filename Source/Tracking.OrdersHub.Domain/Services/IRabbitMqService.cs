namespace Tracking.OrdersHub.Infrastructure.Messaging
{
    public interface IRabbitMqService
    {
        void Publish(object data, string routingKey);
    }
}