using TMPro;
using UnityEngine;

public class UIWallet : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;

    [SerializeField] private TextMeshProUGUI _coinText;
    [SerializeField] private TextMeshProUGUI _diamondText;
    [SerializeField] private TextMeshProUGUI _energyText;

    private void Start()
    {
        foreach (Currency currency in _wallet.Currencies.Values)
            currency.Changed += OnValueChanged;
    }

    private void OnDestroy()
    {
        foreach (Currency currency in _wallet.Currencies.Values)
            currency.Changed -= OnValueChanged;
    }

    private void OnValueChanged(CurrencyType currencyType, int value)
    {
        switch (currencyType)
        {
            case CurrencyType.Coin:
                _coinText.text = value.ToString();
                break;

            case CurrencyType.Diamond:
                _diamondText.text = value.ToString();
                break;

            case CurrencyType.Energy:
                _energyText.text = value.ToString();
                break;

            default:
                break;
        }
    }
}
