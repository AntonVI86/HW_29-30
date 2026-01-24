using System;
using UnityEngine;

public class TimerBehaviour : MonoBehaviour
{
    [SerializeField] private SliderTimeView _sliderTimeViewer;
    [SerializeField] private HeartTimerView _heartTimeViewer;
    [SerializeField] private TextTimeView _textTimeView;

    private Timer _timer;

    public float CurrentTime => _timer.CurrentValue;

    private void Awake()
    {
        _timer = new Timer(this, 10);

        _sliderTimeViewer.Initialize(_timer);
        _heartTimeViewer.Initialize(_timer);
        _textTimeView.Initialize(_timer);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            _timer.Start();

        if (Input.GetKeyDown(KeyCode.Alpha2))
            _timer.Stop();

        if (Input.GetKeyDown(KeyCode.Alpha3))
            _timer.Reset();
    }

    public void StartProcess() => _timer.Start();
    public void StopProcess() => _timer.Stop();
    public void ResetProcess() => _timer.Reset();
}
