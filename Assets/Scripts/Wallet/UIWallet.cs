using TMPro;
using UnityEngine;

public class UIWallet : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _diamondText;
    [SerializeField] private TextMeshProUGUI _energyText;

    private void Awake()
    {
        _wallet.Changed += OnAmounChange;
    }

    private void OnDestroy()
    {
        _wallet.Changed -= OnAmounChange;
    }

    private void OnAmounChange(CurrencyType currencyType, int amount)
    {
        switch (currencyType)
        {
            case CurrencyType.Coin:
                _coinText.text = amount.ToString();
                break;

            case CurrencyType.Diamond:
                _diamondText.text = amount.ToString();
                break;

            case CurrencyType.Energy:
                _energyText.text = amount.ToString();
                break;

            default:
                break;
        }
    }
}
