using MongoDB.Driver;
using TrackingOrders.Core.Entities;
using TrackingOrders.Core.Repositories;

namespace TrackingOrders.Infrastructure.Persistence.Repositories
{
    public class ShippingOrderUpdateRepositoryImp : IShippingOrderUpdateRepository
    {
        private readonly IMongoCollection<ShippingOrderUpdate> _collection;

        public ShippingOrderUpdateRepositoryImp(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingOrderUpdate>("shipping-order-updates");
        }

        public async Task AddAsync(ShippingOrderUpdate update)
        {
            await _collection.InsertOneAsync(update);
        }

        public async Task<List<ShippingOrderUpdate>> GetAllByCodeAsync(string shippingOrderCode)
        {
            return await _collection.Find(so => so.TrackingCode == shippingOrderCode).ToListAsync();
        }
    }
}