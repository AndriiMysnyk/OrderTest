using OrderTest.Domain.Orders;

namespace OrderTest.Domain.Services.Implementations;

internal class OrderService : IOrderService
{
    public async Task<IEnumerable<Order>> GetAll()
    {
        return new[] { new Order() };
    }
}
