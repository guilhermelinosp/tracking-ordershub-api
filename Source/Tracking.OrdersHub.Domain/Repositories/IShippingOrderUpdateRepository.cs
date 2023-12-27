using Tracking.OrdersHub.Domain.Entities;

namespace Tracking.OrdersHub.Domain.Repositories
{
    public interface IShippingOrderUpdateRepository
    {
        Task AddAsync(ShippingOrderUpdate update);

        Task<List<ShippingOrderUpdate>> GetAllByCodeAsync(string shippingOrderCode);
    }
}