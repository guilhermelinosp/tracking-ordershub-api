using TrackingOrders.Core.Entities;

namespace TrackingOrders.Core.Repositories
{
    public interface IShippingOrderUpdateRepository
    {
        Task AddAsync(ShippingOrderUpdate update);

        Task<List<ShippingOrderUpdate>> GetAllByCodeAsync(string shippingOrderCode);
    }
}