using Tracking.OrdersHub.Application.Models.InputModels;
using Tracking.OrdersHub.Application.Models.ViewModels;
using Tracking.OrdersHub.Domain.Events;
using Tracking.OrdersHub.Domain.Repositories;
using Tracking.OrdersHub.Infrastructure.Messaging;

namespace Tracking.OrdersHub.Application.Services
{
    public class TrakingOrderService(IShippingRepository repository, IRabbitMqService rabbitMq)
        : ITrakingOrderService
    {
        public async Task AddUpdate(AddOrderUpdateInputModel model)
        {
            var shippingOrderUpdate = model.ToEntity();

            await repository.AddAsync(shippingOrderUpdate);

            var orderUpdatedEvent =
                new OrderUpdatedEvent(model.TrackingCode, model.ContactEmail, model.Description);

            rabbitMq.Publish(orderUpdatedEvent, "shipping-order-updated");

            if (model.IsShippingCompleted)
            {
                var orderCompletedEvent = new OrderCompletedEvent(model.TrackingCode);

                rabbitMq.Publish(orderCompletedEvent, "shipping-order-completed");
            }
        }

        public async Task<List<OrderUpdateViewModel>> GetAllByCode(string code)
        {
            var shippingOrderUpdates = await repository.GetAllByCodeAsync(code);

            var viewModels = shippingOrderUpdates.Select(so => new OrderUpdateViewModel(so)).ToList();

            return viewModels;
        }
    }
}