using System.Collections.Generic;

public class Wallet
{
    private Dictionary<CurrencyType, ReactiveVariable<CurrencyType, int>> _valuesOfCurrencies = new Dictionary<CurrencyType, ReactiveVariable<CurrencyType, int>>();

    public Wallet(Dictionary<CurrencyType, ReactiveVariable<CurrencyType, int>> valuesOfCurrencies)
    {
        _valuesOfCurrencies = new(valuesOfCurrencies);
    }

    public Dictionary<CurrencyType, ReactiveVariable<CurrencyType, int>> ValueOfCurrency => _valuesOfCurrencies;

    public void AddValue(CurrencyType type, int receivedValue)
    {
        if (receivedValue <= 0)
            return;

        int currentValue = _valuesOfCurrencies[type].Value;
        int result = currentValue + receivedValue;

        _valuesOfCurrencies[type].Value = result;
    }

    public void SubtractValue(CurrencyType type, int receivedValue)
    {
        if (receivedValue <= 0)
            return;

        int currentValue = _valuesOfCurrencies[type].Value;

        if(IsCurrencyValueEnough(type, receivedValue))
        {
            int result = currentValue - receivedValue;

            _valuesOfCurrencies[type].Value = result;
        }
    }

    private bool IsCurrencyValueEnough(CurrencyType type, int receivedValue)
    {
        int currentValue = _valuesOfCurrencies[type].Value;

        if (receivedValue <= currentValue)
            return true;

        return false;
    }
}
