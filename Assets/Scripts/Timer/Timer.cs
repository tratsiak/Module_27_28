using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action<int> TimerStarted;
    public event Action TimerReset;
    public event Action TimerStoped;
    public event Action TimerResumed;
    public event Action TimerEnded;

    [SerializeField] private int _duration;

    private ReactiveVariable<float> _time;

    private bool _isRunning;
    private bool _isStarted;

    public ReactiveVariable<float> CurrentTime => _time;

    public bool IsRunning => _isRunning;

    private void Start()
    {
        _time = new ReactiveVariable<float>(_duration);
    }

    private void Update()
    {
        if (_isRunning)
        {
            _time.Value -= Time.deltaTime;

            if (_time.Value <= 0)
            {
                _isRunning = false;
                TimerEnded?.Invoke();
            }
        }
    }

    public void StartTimer()
    {
        if (_isStarted)
            return;

        _isStarted = true;
        _isRunning = true;

        TimerStarted?.Invoke(_duration);
    }

    public void StopTimer()
    {
        _isRunning = false;

        TimerStoped?.Invoke();
    }

    public void ResetTimer()
    {
        StopTimer();

        _isStarted = false;
        _time.Value = _duration;

        TimerReset?.Invoke();

        StopAllCoroutines();

        StartTimer();
    }

    public void ResumeTimer()
    {
        if (_time.Value > 0)
        {
            _isRunning = true;

            TimerResumed?.Invoke();
        }
    }
}
