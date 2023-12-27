namespace Tracking.OrdersHub.Domain.Events
{
    public class OrderUpdatedEvent(string trackingCode, string contactEmail, string description)
    {
        public string TrackingCode { get; private set; } = trackingCode;
        public string ContactEmail { get; private set; } = contactEmail;
        public string Description { get; private set; } = description;
    }
}