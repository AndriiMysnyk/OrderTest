using Microsoft.AspNetCore.Mvc;

using OrderTest.Read.Models;
using OrderTest.Read.Services;

using System.Net;

namespace OrderTest.Host.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderReadService _orderService;

        public OrdersController(
            IOrderReadService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Order>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return Ok(await _orderService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(Order), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<Order>>> Get(Guid id)
        {
            Order? result = await _orderService.Find(id);

            return result is not null ? Ok(result) : NotFound();
        }
    }
}