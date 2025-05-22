using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerExample : MonoBehaviour
{
    private Timer _timer;

    private void Awake()
    {
        _timer = GetComponent<Timer>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1))
            _timer.StartTimer();

        if (Input.GetKey(KeyCode.Alpha2))
            _timer.StopTimer();

        if (Input.GetKey(KeyCode.Alpha3))
            _timer.ResumeTimer();

        if (Input.GetKey(KeyCode.Alpha4))
            _timer.ResetTimer();
    }
}
