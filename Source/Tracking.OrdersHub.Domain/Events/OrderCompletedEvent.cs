namespace Tracking.OrdersHub.Domain.Events
{
    public class OrderCompletedEvent(string trackingCode)
    {
        public string TrackingCode { get; private set; } = trackingCode;
    }
}