using Microsoft.AspNetCore.Mvc;
using Tracking.OrdersHub.Application.Models.InputModels;
using Tracking.OrdersHub.Application.Services;

namespace Tracking.OrdersHub.API.Controllers
{
    [ApiController]
    [Route("api/shipping-order-updates")]
    public class TrakingOrdersController(ITrakingOrderService service) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Post(AddOrderUpdateInputModel model)
        {
            await service.AddUpdate(model);

            return NoContent();
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetAllByCode(string code)
        {
            var viewModel = await service.GetAllByCode(code);

            return Ok(viewModel);
        }
    }
}