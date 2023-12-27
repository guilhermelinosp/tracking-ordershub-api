using Tracking.OrdersHub.Domain.Entities;

namespace Tracking.OrdersHub.Application.Models.ViewModels
{
    public class ShippingOrderUpdateViewModel
    {
        public ShippingOrderUpdateViewModel(ShippingOrderUpdate shippingOrderUpdate)
        {
            TrackingCode = shippingOrderUpdate.TrackingCode;
            Description = shippingOrderUpdate.Description;
            UpdatedAt = shippingOrderUpdate.UpdatedAt;
        }

        public string TrackingCode { get; private set; }
        public string Description { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}