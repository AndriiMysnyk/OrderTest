using OrderTest.Read.Models;

namespace OrderTest.Read.Translators;

public interface IOrderTranslator
{
    public Order Translate(Domain.Orders.Order domainOrder);
}
