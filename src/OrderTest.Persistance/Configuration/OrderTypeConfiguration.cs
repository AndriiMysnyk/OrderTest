using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using OrderTest.Domain.Orders;
using OrderTest.Persistance.Configuration;

namespace OrderTest.Persistance.Configuration;

internal class OrderTypeConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder
            .HasKey(p => p.Id);

        builder
            .Property(e => e.Status)
            .IsRequired();

        builder
            .Property(e => e.Description)
            .IsRequired();

        builder
            .OwnsOne(e => e.OverallPrice, e => e.ConfigureMoney())
            .Navigation(e => e.OverallPrice)
            .IsRequired();

        builder
            .OwnsMany(x => x.Items, i => i.ConfigureOrderItem())
            .Navigation(x => x.Items)
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}
