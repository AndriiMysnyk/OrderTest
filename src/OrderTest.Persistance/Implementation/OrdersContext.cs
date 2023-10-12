using Microsoft.EntityFrameworkCore;

using OrderTest.Domain.Orders;
using OrderTest.Persistance.Configuration;

namespace OrderTest.Persistance.Implementation;

internal class OrdersContext : DbContext, IOrdersContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseInMemoryDatabase(databaseName: "OrdersDemoDb");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfiguration(new OrderTypeConfiguration());
    }

    public DbSet<Order> Orders { get; set; }
}
