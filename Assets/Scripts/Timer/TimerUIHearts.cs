using System.Collections.Generic;
using UnityEngine;

public class TimerUIHearts : MonoBehaviour
{
    [SerializeField] private Timer _timer;
    [SerializeField] private GameObject _heartPrefab;

    private List<GameObject> _hearts = new List<GameObject>();

    private void Start()
    {
        _timer.TimerStarted += Initialize;
        _timer.TimerReset += OnReset;
        _timer.Ticked += OnTicked;
    }

    private void OnDestroy()
    {
        _timer.TimerStarted -= Initialize;
        _timer.TimerReset -= OnReset;
        _timer.Ticked -= OnTicked;
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
    }

    private void OnTicked(int tick) => _hearts[tick].SetActive(false);

    private void OnReset()
    {
        foreach (GameObject heart in _hearts)
            heart.SetActive(true);
    }
}
