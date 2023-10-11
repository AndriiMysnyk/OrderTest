using Microsoft.AspNetCore.Mvc;

using OrderTest.Domain.Orders;
using OrderTest.Domain.Services;

namespace OrderTest.Host.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IOrderService _orderService;

        public OrdersController(
            ILogger<OrdersController> logger,
            IOrderService orderService)
        {
            _logger = logger;
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }
    }
}