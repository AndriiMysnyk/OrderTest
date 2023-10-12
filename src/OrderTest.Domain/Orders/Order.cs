using OrderTest.Contract;

namespace OrderTest.Domain.Orders;

public sealed class Order
{
    public Order(string description)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException($"{nameof(Order)} {nameof(description)} should not be null or empty.");
        }

        Id = Guid.NewGuid();
        Status = OrderStatus.Created;
        Description = description;
        _items = new List<OrderItem>();
    }

    public Guid Id { get; }

    public OrderStatus Status { get; private set; }

    public string Description { get; }

    public DateTime? SubmissionDate { get; private set; }

    public DateTime? PaymentDate { get; private set; }

    public List<OrderItem> _items;
    public IReadOnlyCollection<OrderItem> Items { get { return _items; } }

    public Money? OverallPrice { get; private set; }

    public void Additem(OrderItem item)
    {
        if (Status is not OrderStatus.Created)
        {
            throw new InvalidOperationException($"The order items can not be added when order is in '{Status}' status.");
        }

        if (_items.Any() && _items.GroupBy(i => i.Price.Currency).Count() > 1)
        {
            throw new ArgumentException($"{nameof(Order)} {nameof(item)} prices should be in one currency.");
        }

        _items.Add(item);
        OverallPrice = CalculateOverallPrice();
    }

    public void Submit()
    {
        if (Status is OrderStatus.Submitted)
        {
            return;
        }

        if (Status is OrderStatus.Payed || Status is OrderStatus.Cancelled)
        {
            throw new InvalidOperationException($"The order '{Description}' is in '{Status}' status and can not be sumbitted.");
        }

        SubmissionDate = DateTime.Now;
        Status = OrderStatus.Submitted;
    }

    public void Pay()
    {
        if (Status is OrderStatus.Payed || Status is OrderStatus.Cancelled)
        {
            throw new InvalidOperationException($"The order '{Description}' is {Status} and can not be payed.");
        }

        if (Status is not OrderStatus.Submitted)
        {
            throw new InvalidOperationException($"The order '{Description}' is not submitted to be payed.");
        }

        Status = OrderStatus.Payed;
        PaymentDate = DateTime.Now;
    }

    public void Cancel()
    {
        if (Status is OrderStatus.Cancelled)
        {
            return;
        }

        Status = OrderStatus.Cancelled;
    }

    private Money? CalculateOverallPrice()
    {
        return _items.Any() ? _items.Select(i => i.Price * i.Count).Aggregate((a, b) => a + b) : null;
    }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private Order()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    {
    }
}
