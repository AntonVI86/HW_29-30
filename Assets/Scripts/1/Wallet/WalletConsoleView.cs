using System.Collections.Generic;
using UnityEngine;

public class WalletConsoleView : MonoBehaviour
{
    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        foreach (KeyValuePair<CurrencyType, ReactiveVariable<CurrencyType, int>> item in _wallet.ValueOfCurrency)
        {
            item.Value.Changed += OnCurrencyValueChanged;
        }
    }

    public void OnCurrencyValueChanged(CurrencyType type, int value)
    {
        foreach (KeyValuePair<CurrencyType, ReactiveVariable<CurrencyType, int>> item in _wallet.ValueOfCurrency)
        {
            Debug.Log(item.Key + " - " + item.Value.Value);
        }
    }

    private void OnDestroy()
    {
        foreach (KeyValuePair<CurrencyType, ReactiveVariable<CurrencyType, int>> item in _wallet.ValueOfCurrency)
        {
            item.Value.Changed -= OnCurrencyValueChanged;
        }
    }
}
