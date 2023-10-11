using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderTest.Domain.Orders;

namespace OrderTest.Persistance.Configuration;

internal static class ConfigurationExtensions
{
    internal static OwnedNavigationBuilder<OrderItem, Money> ConfigureMoney(this OwnedNavigationBuilder<OrderItem, Money> builder)
    {
        builder
            .Property(e => e.Amount)
            .HasPrecision(24, 2)
            .IsRequired();

        builder
            .Property(e => e.Currency)
            .IsRequired();

        return builder;
    }

    internal static OwnedNavigationBuilder<Order, OrderItem> ConfigureOrderItem(this OwnedNavigationBuilder<Order, OrderItem> builder)
    {
        builder
            .Property(e => e.Description)
            .IsRequired();

        builder
            .OwnsOne(e => e.Price, e => e.ConfigureMoney())
            .Navigation(e => e.Price)
            .IsRequired();

        return builder;
    }
}
