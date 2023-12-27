using Tracking.OrdersHub.Domain.Entities;

namespace Tracking.OrdersHub.Domain.Repositories
{
    public interface IShippingRepository
    {
        Task AddAsync(TrackingOrderUpdated update);

        Task<List<TrackingOrderUpdated>> GetAllByCodeAsync(string shippingOrderCode);
    }
}