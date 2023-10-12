using System.Diagnostics;

namespace OrderTest.Domain.Orders;

public sealed record OrderItem
{
    public OrderItem(string description, Money price, int count = 1)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException($"{nameof(OrderItem)} {nameof(description)} should not be null or empty.");
        }

        if (price is null)
        {
            throw new ArgumentException($"{nameof(OrderItem)} {nameof(price)} should not be null.");
        }

        Description = description;
        Price = price;
        Count = count;
    }

    public string Description { get; }

    public Money Price { get; }

    public int Count { get; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private OrderItem()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}
