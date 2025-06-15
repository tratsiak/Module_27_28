using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Wallet
{
    private List<Currency> _currencies = new List<Currency>();

    public IReadOnlyList<Currency> Currencies => _currencies;

    public Wallet()
    {
        foreach (CurrencyType currency in Enum.GetValues(typeof(CurrencyType)))
            _currencies.Add(new Currency(currency, default));
    }

    public void Add(CurrencyType currencyType, int amount)
    {
        _currencies.Where(currency => currency.Type == currencyType).First().Add(amount);
    }

    public void Spend(CurrencyType currencyType, int amount)
    {
        Currency currency = _currencies.Where(currency => currency.Type == currencyType).First();

        if (currency.Amount.Value < amount)
        {
            Debug.Log($"Insufficient amount of {currencyType}.");
            return;
        }

        currency.Spend(amount);
    }
}
