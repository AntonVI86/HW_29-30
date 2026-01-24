using System;
using System.Collections;
using UnityEngine;

public class Timer
{
    public event Action Reseted;

    private MonoBehaviour _behaviour;

    private ReactiveVariables<float> _currentValue = new();

    private float _defaultValue;

    private Coroutine _coroutine;

    public ReactiveVariables<float> CurrentValue => _currentValue;

    public Timer(MonoBehaviour behaviour, ReactiveVariables<float> value)
    {
        _defaultValue = value.Value;
        _currentValue.Value = _defaultValue;
        _behaviour = behaviour;
    }

    public void Start() 
    {
        if (_coroutine != null)
            Stop();

        _coroutine = _behaviour.StartCoroutine(Process());
    }

    public void Stop()
    {
        if (_coroutine != null)
            _behaviour.StopCoroutine(_coroutine);
    }

    public void Reset()
    {
        _currentValue.Value = _defaultValue;
        Reseted?.Invoke();

        Stop();
        _coroutine = null;
        Start();
    }

    private IEnumerator Process()
    {
        while (_currentValue.Value > 0)
        {
            _currentValue.Value -= Time.deltaTime;
            yield return null;
        }
    }
}
