using OrderTest.Contract;
using OrderTest.Domain.Orders;
using OrderTest.Write.Exceptions;
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
        Order order = new Order(description);
        await _repository.Create(order);
    }

    public async Task AddItem(Guid orderId, string description, decimal amount, Currency currency, int count = 1)
    {
        Order? order = await _repository.Find(orderId);
        if (order is null)
        {
            throw new OrderNotFoundException(orderId);
        }

        order.Additem(
            new OrderItem(
                description,
                new Money(amount, currency),
                count)
            );

        _repository.CommitChanges();
    }

    public async Task ChangeStatus(Guid orderId, OrderStatus orderStatus)
    {
        Order? order = await _repository.Find(orderId);
        if (order is null)
        {
            throw new OrderNotFoundException(orderId);
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
