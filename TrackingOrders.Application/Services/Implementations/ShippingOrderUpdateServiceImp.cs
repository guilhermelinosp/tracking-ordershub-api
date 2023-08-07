using TrackingOrders.Application.Models.InputModels;
using TrackingOrders.Application.Models.ViewModels;
using TrackingOrders.Core.Events;
using TrackingOrders.Core.Repositories;
using TrackingOrders.Infrastructure.Messaging;

namespace TrackingOrders.Application.Services.Implementations
{
    public class ShippingOrderUpdateService : IShippingOrderUpdateService
    {
        private readonly IShippingOrderRepository _repository;
        private readonly IMessageBusService _messageBus;

        public ShippingOrderUpdateService(IShippingOrderRepository repository, IMessageBusService messageBus)
        {
            _messageBus = messageBus;
            _repository = repository;
        }

        public async Task AddUpdate(AddShippingOrderUpdateInputModel model)
        {
            var shippingOrderUpdate = model.ToEntity();

            await _repository.AddAsync(shippingOrderUpdate);

            var orderUpdatedEvent =
                new ShippingOrderUpdatedEvent(model.TrackingCode, model.ContactEmail, model.Description);

            _messageBus.Publish(orderUpdatedEvent, "shipping-order-updated");

            if (model.IsShippingCompleted)
            {
                var orderCompletedEvent = new ShippingOrderCompletedEvent(model.TrackingCode);

                _messageBus.Publish(orderCompletedEvent, "shipping-order-completed");
            }
        }

        public async Task<List<ShippingOrderUpdateViewModel>> GetAllByCode(string code)
        {
            var shippingOrderUpdates = await _repository.GetAllByCodeAsync(code);

            var viewModels = shippingOrderUpdates.Select(so => new ShippingOrderUpdateViewModel(so)).ToList();

            return viewModels;
        }
    }
}