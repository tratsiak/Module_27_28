using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour, IDisposable
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _value;

    private Currency _currency;

    public void Initialize(Currency currency, Sprite icon)
    {
        _currency = currency;
        _icon.sprite = icon;

        _currency.Amount.Changed += OnValueChanged;
    }

    public void Dispose()
    {
        _currency.Amount.Changed -= OnValueChanged;
    }

    public void OnValueChanged(int oldValue, int value)
    {
        _value.text = value.ToString();
    }
}
