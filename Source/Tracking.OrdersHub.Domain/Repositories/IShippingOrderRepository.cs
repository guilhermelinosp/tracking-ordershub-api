using Tracking.OrdersHub.Domain.Entities;

namespace Tracking.OrdersHub.Domain.Repositories
{
    public interface IShippingOrderRepository
    {
        Task AddAsync(ShippingOrderUpdate update);

        Task<List<ShippingOrderUpdate>> GetAllByCodeAsync(string shippingOrderCode);
    }
}