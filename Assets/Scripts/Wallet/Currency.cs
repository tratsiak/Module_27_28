using UnityEngine;

public class Currency
{
    private ReactiveVariable<int> _amount;

    public Currency(CurrencyType type, int value)
    {
        Type = type;
        _amount = new ReactiveVariable<int>(value);
    }

    public CurrencyType Type { get; private set; }

    public IReadOnlyVariable<int> Amount => _amount;

    public void Add(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("The argument cannot be less than zero");
            return;
        }

        _amount.Value += amount;
    }

    public void Spend(int amount)
    {
        if (amount < 0)
        {
            Debug.LogError("The argument cannot be less than zero");
            return;
        }

        _amount.Value -= amount;
    }
}
