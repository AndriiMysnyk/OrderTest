using OrderTest.Read.Models;
using OrderTest.Read.Repositories;
using OrderTest.Read.Translators;

namespace OrderTest.Read.Services.Implementation;

internal class OrderReadService : IOrderReadService
{
    private readonly IOrdersReadRepository _repository;
    private readonly IOrderTranslator _translator;

    public OrderReadService(
        IOrdersReadRepository repository,
        IOrderTranslator translator)
    {
        _repository = repository;
        _translator = translator;
    }

    public async Task<IEnumerable<Order>> GetAll()
    {
        return (await _repository.GetAll()).Select(o => _translator.Translate(o));
    }

    public async Task<Order?> Find(Guid id)
    {
        Domain.Orders.Order? result = await _repository.Find(id);

        return result is null ? null : _translator.Translate(result);
    }
}
