using OrderTest.Domain.Orders;

namespace OrderTest.Read.Services;

public interface IOrderReadService
{
    Task<IEnumerable<Order>> GetAll();
}
