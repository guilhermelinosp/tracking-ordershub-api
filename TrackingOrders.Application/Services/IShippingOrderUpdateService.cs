using TrackingOrders.Application.Models.InputModels;
using TrackingOrders.Application.Models.ViewModels;

namespace TrackingOrders.Application.Services
{
    public interface IShippingOrderUpdateService
    {
        Task AddUpdate(AddShippingOrderUpdateInputModel model);

        Task<List<ShippingOrderUpdateViewModel>> GetAllByCode(string code);
    }
}