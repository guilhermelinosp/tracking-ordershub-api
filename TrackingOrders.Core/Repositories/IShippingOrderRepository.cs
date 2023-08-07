﻿using TrackingOrders.Core.Entities;

namespace TrackingOrders.Core.Repositories
{
    public interface IShippingOrderRepository
    {
        Task AddAsync(ShippingOrderUpdate update);

        Task<List<ShippingOrderUpdate>> GetAllByCodeAsync(string shippingOrderCode);
    }
}