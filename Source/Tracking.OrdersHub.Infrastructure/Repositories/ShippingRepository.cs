using MongoDB.Driver;
using Tracking.OrdersHub.Domain.Entities;
using Tracking.OrdersHub.Domain.Repositories;

namespace Tracking.OrdersHub.Infrastructure.Persistence.Repositories
{
    public class ShippingRepository(IMongoDatabase database) : IShippingRepository
    {
        private readonly IMongoCollection<TrackingOrderUpdated> _collection = database.GetCollection<TrackingOrderUpdated>("shipping-order-updates");

        public async Task AddAsync(TrackingOrderUpdated update)
        {
            await _collection.InsertOneAsync(update);
        }

        public async Task<List<TrackingOrderUpdated>> GetAllByCodeAsync(string shippingOrderCode)
        {
            return await _collection.Find(so => so.TrackingCode == shippingOrderCode).ToListAsync();
        }
    }
}