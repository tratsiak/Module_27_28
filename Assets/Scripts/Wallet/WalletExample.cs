using UnityEngine;

public class WalletExample : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    private void Start()
    {
        _wallet.AddCurrency(CurrencyType.Coin, 70);
        _wallet.AddCurrency(CurrencyType.Diamond, 50);
        _wallet.AddCurrency(CurrencyType.Energy, 30);

        _wallet.SpendCurrency(CurrencyType.Coin, 5);
    }
}
