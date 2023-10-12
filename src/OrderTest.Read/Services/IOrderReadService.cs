using OrderTest.Read.Models;

namespace OrderTest.Read.Services;

public interface IOrderReadService
{
    Task<IEnumerable<Order>> GetAll();

    Task<Order?> Find(Guid id);
}
