using Tracking.OrdersHub.Domain.Entities;

namespace Tracking.OrdersHub.Application.Models.InputModels
{
    public class AddOrderUpdateInputModel
    {
        public string? TrackingCode { get; set; }
        public string? Description { get; set; }
        public bool IsShippingCompleted { get; set; }
        public string? ContactEmail { get; set; }
        
        public TrackingOrderUpdated ToEntity()
        {
            return new TrackingOrderUpdated(TrackingCode!, Description!, IsShippingCompleted);
        }
    }
}