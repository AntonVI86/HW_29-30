using UnityEngine;

public abstract class TimerView : MonoBehaviour
{
    protected Timer Timer;

    private void Start()
    {
        Timer.ValueChanged += OnValueChanged;
        Timer.Reseted += OnReseted;
    }

    public abstract void Initialize(Timer timer);
    public abstract void OnValueChanged(float value);
    public abstract void OnReseted();

    private void OnDestroy()
    {
        Timer.ValueChanged -= OnValueChanged;
        Timer.Reseted -= OnReseted;
    }
}
