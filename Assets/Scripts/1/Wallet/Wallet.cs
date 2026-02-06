using System;
using System.Collections.Generic;

public class Wallet
{
    private Dictionary<CurrencyType, ReactiveVariable<int>> _valuesOfCurrencies = new Dictionary<CurrencyType, ReactiveVariable<int>>();

    public Wallet(Dictionary<CurrencyType, ReactiveVariable<int>> valuesOfCurrencies)
    {
        _valuesOfCurrencies = new(valuesOfCurrencies);
    }

    public IEnumerable<ReactiveVariable<int>> Values => _valuesOfCurrencies.Values;

    public void AddValue(CurrencyType type, int receivedValue)
    {
        CheckReceivedValue(receivedValue);

        int currentValue = _valuesOfCurrencies[type].Value;
        int result = currentValue + receivedValue;

        _valuesOfCurrencies[type].Value = result;
    }

    public void SubtractValue(CurrencyType type, int receivedValue)
    {
        CheckReceivedValue(receivedValue);

        int currentValue = _valuesOfCurrencies[type].Value;

        if(IsCurrencyValueEnough(type, receivedValue))
        {
            int result = currentValue - receivedValue;

            _valuesOfCurrencies[type].Value = result;
        }
    }

    public bool IsCurrencyValueEnough(CurrencyType type, int receivedValue)
    {
        CheckReceivedValue(receivedValue);

        int currentValue = _valuesOfCurrencies[type].Value;

        if (receivedValue <= currentValue)
            return true;

        return false;
    }

    private bool CheckReceivedValue(int receivedValue)
    {
        if (receivedValue <= 0)
            throw new ArgumentOutOfRangeException(nameof(receivedValue), "Значение должно быть больше 0");

        return true;
    }
}
