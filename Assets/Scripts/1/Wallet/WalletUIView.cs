using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WalletUIView : MonoBehaviour
{
    [SerializeField] private CurrencyView _currencyViewPrefab;
    [SerializeField] private Sprite[] _icon;

    private List<CurrencyView> _currencyViews = new List<CurrencyView>();

    private Wallet _wallet;

    public void Initialize(Wallet wallet)
    {
        _wallet = wallet;

        foreach(ReactiveVariable<int> value in _wallet.Values)
            value.Changed += OnCurrencyValueChanged;

        CreateView();
    }

    public void OnCurrencyValueChanged(int oldValue, int value)
    {
        for (int i = 0; i < _currencyViews.Count; i++)
            _currencyViews[i].UpdateInfo(_wallet.Values.ElementAt(i).Value);
    }

    private void CreateView()
    {
        int index = 0;
        CurrencyType type = 0;

        foreach (ReactiveVariable<int> item in _wallet.Values)
        {
            CurrencyView view = Instantiate(_currencyViewPrefab, transform);
            view.Initialize(type,_icon[index], item.Value);
            _currencyViews.Add(view);

            index++;
            type++;
        }
    }

    private void OnDestroy()
    {
        foreach (ReactiveVariable<int> value in _wallet.Values)
            value.Changed -= OnCurrencyValueChanged;
    }
}
