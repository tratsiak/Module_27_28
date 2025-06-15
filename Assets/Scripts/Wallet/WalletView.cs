using System.Collections.Generic;
using UnityEngine;

public class WalletView : MonoBehaviour
{
    [SerializeField] private CurrencyView _currencyViewPrefab;

    [SerializeField] private Sprite[] _icons;

    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        foreach (Currency currency in _wallet.Currencies)
        {
            CurrencyView currencyView = Instantiate(_currencyViewPrefab, transform, false);
            currencyView.Initialize(currency, _icons[(int)currency.Type]);
        }
    }
}
