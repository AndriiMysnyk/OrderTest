using Microsoft.EntityFrameworkCore;

using OrderTest.Contract;
using OrderTest.Domain.Orders;
using OrderTest.Read.Repositories;

namespace OrderTest.Persistance.Implementation;

internal class OrdersRepository : IOrdersReadRepository
{
    public OrdersRepository()
    {
        using OrdersContext context = new();
        context.Orders.Add(
            new Order(
                "Restaurant visit",
                new OrderItemCollection(
                    new[] {
                        new OrderItem("Cup of coffe", new(10, Currency.USD)),
                        new OrderItem("Cookie", new(5, Currency.USD))
                    }
                )));
        context.SaveChanges();
    }

    public Task<List<Order>> GetAll()
    {
        using OrdersContext context = new();
        return context.Orders.ToListAsync();
    }

    public Task<Order?> Find(Guid id)
    {
        using OrdersContext context = new();
        return context.Orders.FirstOrDefaultAsync(o => o.Id == id);
    }
}
