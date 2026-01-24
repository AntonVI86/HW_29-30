using System.Collections.Generic;
using UnityEngine;

public class WalletExample : MonoBehaviour
{
    [SerializeField] private WalletUIView _uiView;
    [SerializeField] private WalletConsoleView _consoleView;

    private Wallet _wallet;

    private Dictionary<CurrencyType, ReactiveVariable<CurrencyType, int>> _valuesOfCurrencies = new();

    private int _minValue = 1;
    private int _maxValue = 5;

    private void Awake()
    {
        _valuesOfCurrencies.Add(CurrencyType.Coin, new ReactiveVariable<CurrencyType, int>(CurrencyType.Coin, 10)) ;
        _valuesOfCurrencies.Add(CurrencyType.Diamond, new ReactiveVariable<CurrencyType, int>(CurrencyType.Diamond, 5));
        _valuesOfCurrencies.Add(CurrencyType.Food, new ReactiveVariable<CurrencyType, int>(CurrencyType.Food, 10));

        _wallet = new Wallet(_valuesOfCurrencies);

        _uiView.Initialize(_wallet);
        _consoleView.Initialize(_wallet);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _wallet.AddValue(CurrencyType.Coin, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _wallet.AddValue(CurrencyType.Diamond, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _wallet.AddValue(CurrencyType.Food, 1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _wallet.SubtractValue(CurrencyType.Coin, addedValue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _wallet.SubtractValue(CurrencyType.Diamond, addedValue);
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            int addedValue = Random.Range(_minValue, _maxValue);
            _wallet.SubtractValue(CurrencyType.Food, addedValue);
        }
    }
}
