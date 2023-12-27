using Tracking.OrdersHub.Domain.Entities;

namespace Tracking.OrdersHub.Application.Models.ViewModels
{
    public class OrderUpdateViewModel(TrackingOrderUpdated trackingOrderUpdated)
    {
        public string TrackingCode { get; private set; } = trackingOrderUpdated.TrackingCode;
        public string Description { get; private set; } = trackingOrderUpdated.Description;
        public DateTime UpdatedAt { get; private set; } = trackingOrderUpdated.UpdatedAt;
    }
}