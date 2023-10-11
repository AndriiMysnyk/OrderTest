using OrderTest.Domain.Orders;
using OrderTest.Read.Repositories;

namespace OrderTest.Persistance.Implementation;

internal class OrdersRepository : IOrdersReadRepository
{
    public OrdersRepository()
    {
        //using OrdersContext context = new();
        //context.Orders.Add(
        //    new Order("Restaurant visit", new[] { new OrderItem("Cup of coffe", new(10, Currency.USD)) })
        //    );
        //context.SaveChanges();
    }

    public IList<Order> GetAll()
    {
        using OrdersContext context = new();
        return context.Orders.ToList();
    }
}
