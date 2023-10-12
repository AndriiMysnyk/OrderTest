using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderTest.Domain.Orders;

namespace OrderTest.Persistance.Configuration;

internal static class ConfigurationExtensions
{
    internal static OwnedNavigationBuilder<Order, OrderItemCollection> ConfigureOrderItemCollection(
        this OwnedNavigationBuilder<Order, OrderItemCollection> builder)
    {
        builder
            .OwnsMany(x => x.Items, i => i.ConfigureOrderItem())
            .Navigation(x => x.Items)
            .UsePropertyAccessMode(PropertyAccessMode.Field);

        builder
            .OwnsOne(e => e.OverallPrice, e => e.ConfigureMoney())
            .Navigation(e => e.OverallPrice)
            .IsRequired();

        return builder;
    }

    internal static OwnedNavigationBuilder<OrderItemCollection, OrderItem> ConfigureOrderItem(
        this OwnedNavigationBuilder<OrderItemCollection, OrderItem> builder)
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

    internal static OwnedNavigationBuilder<TOwner, Money> ConfigureMoney<TOwner>(
        this OwnedNavigationBuilder<TOwner, Money> builder)
        where TOwner : class
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
}
