using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private CurrencyView _currencyViewPrefab;

    [SerializeField] private Sprite[] _icons;

    private Dictionary<CurrencyType, CurrencyView> _currencies = new Dictionary<CurrencyType, CurrencyView>();

    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        foreach (Currency currency in _wallet.Currencies.Values)
        {
            CurrencyView currencyView = Instantiate(_currencyViewPrefab, transform, false);
            currencyView.Initialize(_icons[(int)currency.Type]);

            _currencies.Add(currency.Type, currencyView);

            currency.Amount.Changed += currencyView.OnValueChanged;
        }
    }

    private void OnDestroy()
    {
        foreach (Currency currency in _wallet.Currencies.Values)
            currency.Amount.Changed -= _currencies[currency.Type].OnValueChanged;
    }
}
