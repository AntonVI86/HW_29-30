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
        foreach (CurrencyType item in _wallet.Key)
        {
            if(_wallet.TryGetValue(item, out ReactiveVariable<int> findValue))
                Debug.Log(item + " - " + findValue.Value);
        }
    }

    private void OnDestroy()
    {
        foreach (ReactiveVariable<int> value in _wallet.Values)
            value.Changed -= OnCurrencyValueChanged;
    }
}
