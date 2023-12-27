using Microsoft.AspNetCore.Mvc;
using Tracking.OrdersHub.Application.Models.InputModels;
using Tracking.OrdersHub.Application.Services;

namespace Tracking.OrdersHub.API.Controllers
{
    [ApiController]
    [Route("api/shipping-order-updates")]
    public class ShippingOrderUpdatesController : ControllerBase
    {
        private readonly IShippingOrderUpdateService _service;

        public ShippingOrderUpdatesController(IShippingOrderUpdateService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(AddShippingOrderUpdateInputModel model)
        {
            await _service.AddUpdate(model);

            return NoContent();
        }

        [HttpGet("{code}")]
        public async Task<IActionResult> GetAllByCode(string code)
        {
            var viewModel = await _service.GetAllByCode(code);

            return Ok(viewModel);
        }
    }
}