using UnityEngine;
using UnityEngine.UI;

public class SliderTimeView : TimerView
{
    [SerializeField] private Slider _timeBar;

    private float _speed = 10;

    public override void Initialize(Timer timer)
    {
        Timer = timer;

        _timeBar.gameObject.SetActive(true);
        _timeBar.maxValue = Timer.CurrentValue;
        _timeBar.value = Timer.CurrentValue;
    }

    public override void OnReseted()
    {
        _timeBar.value = Timer.CurrentValue;
    }

    public override void OnValueChanged(float value)
    {
        _timeBar.value = Mathf.Lerp(_timeBar.value, Timer.CurrentValue, _speed * Time.deltaTime);
    }
}
