namespace OrderTest.Read.Models;

public class OrderItem
{
    public OrderItem(string description, Money price)
    {
        Description = description;
        Price = price;
    }

    public string Description { get; }

    public Money Price { get; }
}
