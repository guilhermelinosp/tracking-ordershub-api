using Microsoft.AspNetCore.Mvc;
using Tracking.OrdersHub.Application.Models.InputModels;
using Tracking.OrdersHub.Application.Services;

namespace Tracking.OrdersHub.API.Controllers
{
    [ApiController]
    [Route("api/shipping-orders")]
    public class TrakingController(ITrakingOrderService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(AddOrderUpdatedInputModel model)
        {
            await service.AddUpdate(model);
            
            var result = await service.GetAllByCode(model.TrackingCode!);
            
            var viewModel = new { Message = "Order updated successfully", Order = result };

            return Ok(viewModel);
        }
    }
}