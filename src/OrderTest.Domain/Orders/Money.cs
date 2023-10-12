namespace OrderTest.Domain.Orders;

public sealed record Money
{
    public Money(decimal amount, Currency currency)
    {
        if (amount < 0)
        {
            throw new ArgumentException($"{nameof(Money)} {nameof(amount)} cannot be less then 0");
        }

        Amount = amount;
        Currency = currency;
    }

    internal Money(Money money)
    {
        Amount = money.Amount;
        Currency = money.Currency;
    }

    public decimal Amount { get; }

    public Currency Currency { get; }

    public static Money operator +(Money a, Money b) => a.Add(b);

    public static Money operator -(Money a, Money b) => a.Sub(b);

    private Money Add(Money other)
    {
        CheckCurrencyEquality(other);

        return new Money(Amount + other.Amount, Currency);
    }

    private Money Sub(Money other)
    {
        CheckCurrencyEquality(other);

        return new Money(Amount - other.Amount, Currency);
    }

    private void CheckCurrencyEquality(Money other)
    {
        if (other == null)
        {
            throw new NullReferenceException($"{nameof(other)} is not set.");
        }

        if (other.Currency != Currency)
        {
            throw new ArgumentException("Operation alloved only with Money with same currrency.");
        }
    }
}
