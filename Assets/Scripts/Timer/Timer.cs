using System;
using System.Collections;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public event Action<float> ValueChanged;
    public event Action<int> Ticked;
    public event Action<int> TimerStarted;
    public event Action TimerReset;
    public event Action TimerStoped;
    public event Action TimerResumed;
    public event Action TimerEnded;

    [SerializeField] private int _duration;

    private float _time;
    private int _tick;
    private bool _isRunning;
    private bool _isStarted;

    private void Start()
    {
        _time = _duration;
        _tick = _duration;
    }

    private void Update()
    {
        if (_isRunning)
        {
            _time -= Time.deltaTime;

            ValueChanged?.Invoke(_time);

            if (_time <= 0)
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

        StartCoroutine(Tick());
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
        _time = _duration;
        _tick = _duration;

        TimerReset?.Invoke();

        StopAllCoroutines();

        StartTimer();
    }

    public void ResumeTimer()
    {
        if (_time > 0)
        {
            _isRunning = true;

            TimerResumed?.Invoke();
        }
    }

    private IEnumerator Tick()
    {
        while (_time >= 0 || _tick >= 0)
        {
            yield return new WaitUntil(() => _isRunning);

            yield return new WaitForSeconds(1f);

            _tick--;

            Ticked?.Invoke(_tick);
        }
    }
}
