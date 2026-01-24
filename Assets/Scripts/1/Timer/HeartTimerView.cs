using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartTimerView : TimerView
{
    [SerializeField] private Image _heart;

    private List<Image> _hearts = new List<Image>();

    public override void Initialize(Timer timer)
    {
        Timer = timer;

        for (int i = 0; i < timer.CurrentValue; i++)
        {
            Image newHeart = Instantiate(_heart, transform);
            _hearts.Add(newHeart);
        }
    }

    public override void OnReseted()
    {
        foreach (Image item in _hearts)
        {
            item.gameObject.SetActive(true);
        }
    }

    public override void OnValueChanged(float value)
    {
        if(_hearts.Count > Mathf.CeilToInt(value))
        {
            _hearts[Mathf.CeilToInt(value)].gameObject.SetActive(false);
        }   
    }
}
