﻿using OrderTest.Contract;

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

    public static Money operator *(Money money, long multiplier) =>
        new(money.Amount * multiplier, money.Currency);

    public static Money operator +(Money money, Money otherMoney) =>
        money.Currency != otherMoney.Currency
        ? throw new OperationCanceledException($"{nameof(Money)} currencies must be the same")
        : new(money.Amount + otherMoney.Amount, money.Currency);
}
