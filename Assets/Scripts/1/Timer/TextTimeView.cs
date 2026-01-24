using TMPro;
using UnityEngine;

public class TextTimeView : TimerView
{
    [SerializeField] private TMP_Text _timeVisual;

    public override void Initialize(Timer timer)
    {
        Timer = timer;
    }

    public override void OnReseted()
    {
        
    }

    public override void OnValueChanged(float value)
    {
        _timeVisual.text = value.ToString("0.0");
    }
}
