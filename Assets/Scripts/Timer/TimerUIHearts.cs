using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerUIHearts : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _heartPrefab;

    private List<GameObject> _hearts = new List<GameObject>();

    private int _tick;

    private void Start()
    {
        _timer.TimerStarted += Initialize;
        _timer.TimerReset += OnReset;
    }

    private void OnDestroy()
    {
        _timer.TimerStarted -= Initialize;
        _timer.TimerReset -= OnReset;
    }

    public void Initialize(int count)
    {
        if (_hearts.Count != 0)
            return;

        for (int i = 0; i < count; i++)
        {
            GameObject heart = Instantiate(_heartPrefab, transform);
            _hearts.Add(heart);
        }

        _tick = count;

        StartCoroutine(DisableHeartPerSecond());
    }

    private void OnReset()
    {
        foreach (GameObject heart in _hearts)
            heart.SetActive(true);

        _tick = _hearts.Count;
    }

    private IEnumerator DisableHeartPerSecond()
    {
        while (_timer.CurrentTime >= 0 || _tick >= 0)
        {
            yield return new WaitUntil(() => _timer.IsRunning);

            yield return new WaitForSeconds(1f);

            _tick--;

            _hearts[_tick].SetActive(false);
        }
    }
}
