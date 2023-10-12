using Microsoft.AspNetCore.Mvc;

using OrderTest.Contract;
using OrderTest.Read.Models;
using OrderTest.Read.Services;
using OrderTest.Write.Services;

namespace OrderTest.Host.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderReadService _orderReadService;
        private readonly IOrderWriteService _orderWriteService;

        public OrdersController(
            IOrderReadService orderReadService,
            IOrderWriteService orderWriteService)
        {
            _orderReadService = orderReadService;
            _orderWriteService = orderWriteService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAll()
        {
            return Ok(await _orderReadService.GetAll());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> Get(Guid id)
        {
            Order? result = await _orderReadService.Find(id);
            return result is not null ? Ok(result) : NotFound();
        }

        [HttpPost]
        public async Task<ActionResult> Create(string description)
        {
            await _orderWriteService.Create(description);
            return Ok();
        }

        [HttpPost]
        [Route("{id}/items")]
        public async Task<ActionResult> AddItem(Guid id, string orderItemDescription, decimal amount, int currency, int count)
        {
            await _orderWriteService.AddItem(id, orderItemDescription, amount, (Currency)currency, count);
            return Ok();
        }

        [HttpPut]
        [Route("{id}/status/{status}")]
        public async Task<ActionResult> SetStatus(Guid id, int status)
        {
            await _orderWriteService.ChangeStatus(id, (OrderStatus)status);
            return Ok();
        }
    }
}