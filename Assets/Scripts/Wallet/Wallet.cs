using System;
using System.Collections.Generic;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public event Action<CurrencyType, int> Changed;

    private Dictionary<CurrencyType, int> currencies = new Dictionary<CurrencyType, int>();

    private void Start()
    {
        foreach (CurrencyType currency in Enum.GetValues(typeof(CurrencyType)))
            currencies[currency] = 0;
    }

    public void AddCurrency(CurrencyType currencyType, int amount)
    {
        currencies[currencyType] += amount;

        Changed?.Invoke(currencyType, currencies[currencyType]);
    }

    public void SpendCurrency(CurrencyType currencyType, int amount)
    {
        if (currencies[currencyType] <= amount)
            currencies[currencyType] = 0;
        else
            currencies[currencyType] -= amount;

        Changed?.Invoke(currencyType, currencies[currencyType]);
    }
}
