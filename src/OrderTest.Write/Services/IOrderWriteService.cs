using OrderTest.Contract;

namespace OrderTest.Write.Services;

public interface IOrderWriteService
{
    Task Create(string description);

    Task ChangeStatus(Guid orderId, OrderStatus orderStatus);
}
