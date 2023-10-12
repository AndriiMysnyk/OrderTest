using OrderTest.Domain.Orders;

namespace OrderTest.Write.Exceptions;

public class OrderNotFoundException : Exception
{
    public OrderNotFoundException(Guid orderId)
        : base($"The {nameof(Order)} with id {orderId} is not found.")
    {
    }
}
