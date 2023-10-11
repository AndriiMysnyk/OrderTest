namespace OrderTest.Domain.Orders;

public class Order
{
    public Order() => Date = DateTime.Now;

    public DateTime Date { get; }
}
