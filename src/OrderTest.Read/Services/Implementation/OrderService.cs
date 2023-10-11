using OrderTest.Domain.Orders;
using OrderTest.Read.Repositories;
using OrderTest.Read.Services;

namespace OrderTest.Read.Services.Implementation;

internal class OrderService : IOrderReadService
{
    private readonly IOrdersReadRepository _repository;

    public OrderService(IOrdersReadRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        return _repository.GetAll();
    }
}
