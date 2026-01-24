using System;

public class ReactiveVariable<CurrencyType, T>
{
    public event Action<CurrencyType, T> Changed;
    private T _value;
    private CurrencyType _type;

    public ReactiveVariable(CurrencyType type, T value)
    {
        _type = type;
        _value = value;   
    } 

    public ReactiveVariable() => _value = default(T);

    public T Value
    {
        get => _value;
        set
        {
            _value = value;
            Changed?.Invoke(_type, _value);
        }
    }

}
