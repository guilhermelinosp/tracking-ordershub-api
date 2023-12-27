using Tracking.OrdersHub.Application.Models.InputModels;
using Tracking.OrdersHub.Application.Models.ViewModels;

namespace Tracking.OrdersHub.Application.Services
{
    public interface ITrakingOrderService
    {
        Task AddUpdate(AddOrderUpdateInputModel model);

        Task<List<OrderUpdateViewModel>> GetAllByCode(string code);
    }
}