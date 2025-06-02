using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet
{
    private Dictionary<CurrencyType, Currency> _currencies = new Dictionary<CurrencyType, Currency>();

    public IReadOnlyDictionary<CurrencyType, Currency> Currencies => _currencies;

    public Wallet()
    {
        foreach (CurrencyType currency in Enum.GetValues(typeof(CurrencyType)))
            _currencies.Add(currency, new Currency(currency, default));
    }

    public void Add(CurrencyType currencyType, int amount) => _currencies[currencyType].Add(amount);

    public void Spend(CurrencyType currencyType, int amount)
    {
        if (_currencies[currencyType].Amount.Value < amount)
        {
            Debug.Log($"Insufficient amount of {currencyType}.");
            return;
        }

        _currencies[currencyType].Spend(amount);
    }
}
