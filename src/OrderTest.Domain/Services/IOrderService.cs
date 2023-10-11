using OrderTest.Domain.Orders;

namespace OrderTest.Domain.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> GetAll();
}
