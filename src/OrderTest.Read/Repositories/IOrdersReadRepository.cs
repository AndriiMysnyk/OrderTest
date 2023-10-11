using OrderTest.Domain.Orders;

namespace OrderTest.Read.Repositories;

public interface IOrdersReadRepository
{
    public IList<Order> GetAll();
}
