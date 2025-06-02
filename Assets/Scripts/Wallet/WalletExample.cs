using UnityEngine;

public class WalletExample : MonoBehaviour
{
    [SerializeField] private WalletView _walletView;

    private Wallet _wallet;

    private void Awake()
    {
        _wallet = new Wallet();
    }

    private void Start()
    {
        _walletView.Initialize(_wallet);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
            _wallet.Add(CurrencyType.Coin, 10);

        if (Input.GetKeyDown(KeyCode.W))
            _wallet.Add(CurrencyType.Diamond, 10);

        if (Input.GetKeyDown(KeyCode.E))
            _wallet.Add(CurrencyType.Energy, 10);

        if (Input.GetKeyDown(KeyCode.A))
            _wallet.Spend(CurrencyType.Coin, 10);

        if (Input.GetKeyDown(KeyCode.S))
            _wallet.Spend(CurrencyType.Diamond, 10);

        if (Input.GetKeyDown(KeyCode.D))
            _wallet.Spend(CurrencyType.Energy, 10);
    }
}
