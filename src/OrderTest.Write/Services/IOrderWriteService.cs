using OrderTest.Contract;

namespace OrderTest.Write.Services;

public interface IOrderWriteService
{
    Task Create(string description);

    Task AddItem(Guid orderId, string description, decimal amount, Currency currency, int count = 1);

    Task ChangeStatus(Guid orderId, OrderStatus orderStatus);
}
