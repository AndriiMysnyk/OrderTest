using OrderTest.Contract;
using OrderTest.Domain.Orders;
using OrderTest.Write.Repositories;

namespace OrderTest.Write.Services.Implementation;

internal class OrderWriteService : IOrderWriteService
{
    private readonly IOrdersWriteRepository _repository;

    public OrderWriteService(IOrdersWriteRepository repository)
    {
        _repository = repository;
    }

    public async Task Create(string description)
    {
        Order order = new Order(
            description,
            new OrderItemCollection(
                new[] {
                    new OrderItem("Cup of coffe", new(10, Currency.USD))
                }
            ));
        await _repository.Create(order);
    }

    public async Task ChangeStatus(Guid orderId, OrderStatus orderStatus)
    {
        Order? order = await _repository.Find(orderId);
        if (order is null)
        {
            return;
        }

        switch (orderStatus)
        {
            case OrderStatus.Submitted:
                order.Submit();
                break;
            case OrderStatus.Payed:
                order.Pay();
                break;
            case OrderStatus.Cancelled:
                order.Cancel();
                break;
        }
        _repository.CommitChanges();
    }
}
