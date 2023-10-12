using OrderTest.Read.Models;

namespace OrderTest.Read.Translators.Implementation;

internal class OrderTranslator : IOrderTranslator
{
    public Order Translate(Domain.Orders.Order domainOrder) =>
        new Order(
            domainOrder.Id,
            domainOrder.Description,
            domainOrder.Status,
            domainOrder.SubmissionDate,
            domainOrder.PaymentDate,
            domainOrder.Items.Items.Select(i => new OrderItem(i.Description, new Money(i.Price.Amount, i.Price.Currency))).ToList().AsReadOnly(),
            new Money(domainOrder.Items.OverallPrice.Amount, domainOrder.Items.OverallPrice.Currency));
}
