using Tracking.OrdersHub.Application.Models.InputModels;
using Tracking.OrdersHub.Application.Models.ViewModels;

namespace Tracking.OrdersHub.Application.Services
{
    public interface IShippingOrderUpdateService
    {
        Task AddUpdate(AddShippingOrderUpdateInputModel model);

        Task<List<ShippingOrderUpdateViewModel>> GetAllByCode(string code);
    }
}