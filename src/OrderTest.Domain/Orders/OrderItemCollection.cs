namespace OrderTest.Domain.Orders;

public record OrderItemCollection
{
    public OrderItemCollection(IEnumerable<OrderItem> items)
    {
        if (items is null || !items.Any())
        {
            throw new ArgumentException($"{nameof(OrderItemCollection)} {nameof(items)} should not be empty.");
        }

        if (items.GroupBy(i => i.Price.Currency).Count() > 1)
        {
            throw new ArgumentException($"{nameof(OrderItemCollection)} {nameof(items)} prices should be in one currency.");
        }

        Items = items;
        OverallPrice = Items.Select(i => i.Price).Aggregate((a, b) => a + b);
    }

    public IEnumerable<OrderItem> Items { get; }

    public Money OverallPrice { get; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private OrderItemCollection()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}
