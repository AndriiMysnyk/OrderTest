using OrderTest.Domain.Orders;

namespace OrderTest.Write.Repositories;

public interface IOrdersWriteRepository
{
    public Task<Order?> Find(Guid id);

    Task Create(Order order);

    void CommitChanges();
}
