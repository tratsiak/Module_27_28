using UnityEngine;

public class Currency
{
    public Currency(CurrencyType type, int value)
    {
        Type = type;
        Amount = new ReactiveVariable<int>(value);
    }

    public CurrencyType Type { get; private set; }
        
    public ReactiveVariable<int> Amount { get; private set; }

    public void Add(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("The argument cannot be less than zero");
            return;
        }

        Amount.Value += amount;
    }

    public void Spend(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("The argument cannot be less than zero");
            return;
        }

        Amount.Value -= amount;
    }
}
