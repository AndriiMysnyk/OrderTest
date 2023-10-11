namespace OrderTest.Domain.Orders;

public class Order
{
    public Order(string description, IEnumerable<string> items, Money price)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new ArgumentException($"{nameof(Order)} {nameof(description)} should not be null or empty.");
        }

        if (items is null || !items.Any())
        {
            throw new ArgumentException($"{nameof(Order)} {nameof(items)} should not be empty.");
        }

        if (price is null)
        {
            throw new ArgumentException($"{nameof(Order)} {nameof(price)} should not be null.");
        }

        Id = Guid.NewGuid();
        Status = OrderStatus.Prepared;
        Description = description;
        Items = items;
        Price = price;
    }

    public Guid Id { get; }

    public OrderStatus Status { get; private set; }

    public string Description { get; }

    public Money Price { get; }

    public DateTime? SubmissionDate { get; private set; }

    public DateTime? PaymentDate { get; private set; }

    public IEnumerable<string> Items { get; }

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
}
