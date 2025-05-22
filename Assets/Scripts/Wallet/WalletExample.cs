using UnityEngine;

public class WalletExample : MonoBehaviour
{
    private Wallet _wallet;

    private void Awake()
    {
        _wallet = GetComponent<Wallet>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            _wallet.AddCurrency(CurrencyType.Coin, 10);

        if (Input.GetKeyDown(KeyCode.W))
            _wallet.AddCurrency(CurrencyType.Diamond, 10);

        if (Input.GetKeyDown(KeyCode.E))
            _wallet.AddCurrency(CurrencyType.Energy, 10);

        if (Input.GetKeyDown(KeyCode.A))
            _wallet.SpendCurrency(CurrencyType.Coin, 10);

        if (Input.GetKeyDown(KeyCode.S))
            _wallet.SpendCurrency(CurrencyType.Diamond, 10);

        if (Input.GetKeyDown(KeyCode.D))
            _wallet.SpendCurrency(CurrencyType.Energy, 10);
    }
}
