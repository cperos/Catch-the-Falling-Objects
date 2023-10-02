using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Player;

public class TimerManager : MonoBehaviour
{
    [SerializeField] private float _maxTime;
    [SerializeField] private float _time;

    [SerializeField] private bool runTimer = false;

    public delegate void TimerEvent(float time);
    public static event TimerEvent onTimerTick;  // broadcast every tick
    public static event TimerEvent onTimerStart; // broadcast max time at start


    public void Init(float time)
    {
        _maxTime = time;
        _time = time;
    }

    public void ActivateTimer(bool set)
    {
        runTimer = set;
    }

    public void ToggleTimer()
    {
        runTimer = !runTimer;
    }

    public void StopTimer()
    {
        ActivateTimer(false);
    }

    public void StartTimer()
    {
        ActivateTimer(true);
        StartCoroutine(BeginTimer());
        if (onTimerStart != null)
        {
            onTimerStart(_time);
        }
    }

    IEnumerator BeginTimer()
    {
        while (runTimer)
        {
            yield return new WaitForSeconds(1f);
            _time -= 1f;
            if (onTimerTick != null)
            {
                onTimerTick(_time);
            }
        }
    }
}

