using OrderTest.Domain.Orders;

namespace OrderTest.Read.Repositories;

public interface IOrdersReadRepository
{
    public Task<List<Order>> GetAll();

    public Task<Order?> Find(Guid id);
}
