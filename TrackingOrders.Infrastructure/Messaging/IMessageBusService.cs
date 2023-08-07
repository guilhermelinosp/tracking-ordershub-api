namespace TrackingOrders.Infrastructure.Messaging
{
    public interface IMessageBusService
    {
        void Publish(object data, string routingKey);
    }
}