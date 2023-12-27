using Tracking.OrdersHub.Domain.Entities;

namespace Tracking.OrdersHub.Application.Models.InputModels
{
    public class AddShippingOrderUpdateInputModel
    {
        public ShippingOrderUpdate ToEntity()
        {
            return new ShippingOrderUpdate(TrackingCode, Description, IsShippingCompleted);
        }

        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public bool IsShippingCompleted { get; set; }
        public string ContactEmail { get; set; }
    }
}