using UnityEngine;
using UnityEngine.UI;

public class TimerUISlider : MonoBehaviour
{
    [SerializeField] private Timer _timer;

    [SerializeField] private Slider _slider;

    private void Start()
    {
        _timer.TimerStarted += Initialize;
        _timer.CurrentTime.Changed += OnValueChanged;
    }

    private void OnDestroy()
    {
        _timer.TimerStarted -= Initialize;
        _timer.CurrentTime.Changed -= OnValueChanged;
    }

    private void Initialize(int value)
    {
        _slider.maxValue = value;
        _slider.value = value;
    }

    private void OnValueChanged(float oldValue, float value)
    {
        _slider.value = value;
    }
}
