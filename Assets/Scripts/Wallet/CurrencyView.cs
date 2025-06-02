using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CurrencyView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [SerializeField] private TextMeshProUGUI _value;

    public void Initialize(Sprite icon)
    {
        _icon.sprite = icon;
    }

    public void OnValueChanged(int oldValue, int value)
    {
        _value.text = value.ToString();
    }
}
