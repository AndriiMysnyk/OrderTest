namespace OrderTest.Read.Models;

public class OrderItem
{
    public OrderItem(string description, Money price, int count)
    {
        Description = description;
        Price = price;
        Count = count;
    }

    public string Description { get; }

    public Money Price { get; }

    public int Count { get; }
}
