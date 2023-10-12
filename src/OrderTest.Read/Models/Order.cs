using OrderTest.Contract;

namespace OrderTest.Read.Models;

public class Order
{
    public Order(
        Guid id,
        string description,
        OrderStatus status,
        DateTime? submissionDate,
        DateTime? paymentDate,
        IReadOnlyCollection<OrderItem> items,
        Money? overallPrice)
    {
        Id = id;
        Description = description;
        Status = status;
        SubmissionDate = submissionDate;
        PaymentDate = paymentDate;
        Items = items;
        OverallPrice = overallPrice;
    }

    public Guid Id { get; }

    public string Description { get; }

    public OrderStatus Status { get; }

    public DateTime? SubmissionDate { get; }

    public DateTime? PaymentDate { get; }

    public IReadOnlyCollection<OrderItem> Items { get; }

    public Money? OverallPrice { get; }
}
