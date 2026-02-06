using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WalletConsoleView : MonoBehaviour
{
    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        foreach (ReactiveVariable<int> value in _wallet.Values)
            value.Changed += OnCurrencyValueChanged;
    }

    public void OnCurrencyValueChanged(int oldValue, int value)
    {
        foreach (ReactiveVariable<int> item in _wallet.Values)
        {
            //Debug.Log(item.Key + " - " + item.Value);
        }
    }

    private void OnDestroy()
    {
        foreach (ReactiveVariable<int> value in _wallet.Values)
            value.Changed -= OnCurrencyValueChanged;
    }
}
