using TMPro;
using UnityEngine;

public class TextTimeView : TimerView
{
    private Timer _timer;

    [SerializeField] private TMP_Text _view;

    public override void Initialize(Timer timer)
    {
        _timer = timer;

        _timer.CurrentValue.Changed += OnValueChanged;
        _timer.Reseted += OnReseted;
    }

    public override void OnReseted()
    {
        _view.text = _timer.CurrentValue.Value.ToString("0.0");
    }

    public override void OnValueChanged(float value)
    {
        _view.text = _timer.CurrentValue.Value.ToString("0.0");
    }

    private void OnDestroy()
    {
        _timer.CurrentValue.Changed -= OnValueChanged;
        _timer.Reseted -= OnReseted;
    }
}
