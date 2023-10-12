using Microsoft.EntityFrameworkCore;

using OrderTest.Domain.Orders;

namespace OrderTest.Persistance;

public interface IOrdersContext
{
    DbSet<Order> Orders { get; }

    int SaveChanges();
}
