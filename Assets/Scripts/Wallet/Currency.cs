using System;
using UnityEngine;

public class Currency
{
    public event Action<CurrencyType, int> Changed;

    public Currency(CurrencyType currencyType, int value)
    {
        CurrencyType = currencyType;
        Value = value;
    }

    public CurrencyType CurrencyType { get; private set; }
        
    public int Value { get; private set; }

    public void Add(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("The argument cannot be less than zero");
            return;
        }

        Value += amount;

        Changed?.Invoke(CurrencyType, Value);
    }

    public void Spend(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("The argument cannot be less than zero");
            return;
        }

        Value -= amount;

        Changed?.Invoke(CurrencyType, Value);
    }
}
