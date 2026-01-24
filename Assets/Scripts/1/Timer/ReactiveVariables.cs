using System;

public class ReactiveVariables<T>
{
    public event Action<T> Changed;
    private T _value;

    public ReactiveVariables(T value)
    {
        _value = value;
    }

    public ReactiveVariables() => _value = default(T);

    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            Changed?.Invoke(_value);
        }
    }
}
