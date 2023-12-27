namespace Tracking.OrdersHub.Domain.Entities
{
    public class TrackingOrderUpdated(string trackingCode, string description, bool isShippingCompleted)
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string TrackingCode { get; private set; } = trackingCode;
        public string Description { get; private set; } = description;
        public bool IsShippingCompleted { get; private set; } = isShippingCompleted;
        public DateTime UpdatedAt { get; private set; } = DateTime.Now;
    }
}