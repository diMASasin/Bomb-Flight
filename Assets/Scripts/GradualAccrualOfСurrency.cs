using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GradualAccrualOfСurrency : MonoBehaviour
{
    [SerializeField] private Wallet _wallet;
    [SerializeField] private float _timerMaxValue = 1;

    private float _timerValue;
    float _currencyValue;
    float _currencyPerFrame;
    float _endCurrencyValue;

    private void Start()
    {
        ResetTimer();
    }

    public void Add(float value, Rewards rewards, bool changeOnlyText = false)
    {
        StartCoroutine(AddCurrency(value, rewards, changeOnlyText));
    }

    private IEnumerator AddCurrency(float value, Rewards rewards, bool changeOnlyText = false)
    {
        _currencyValue = rewards == Rewards.crystals ? _wallet.Crystals : _wallet.Lightnings;
        _endCurrencyValue = _currencyValue + value;

        while (_timerValue < _timerMaxValue)
        {
            _timerValue += Time.deltaTime;
            _currencyPerFrame = value * Time.deltaTime;
            _currencyValue += _currencyPerFrame;

            if (_currencyValue < _endCurrencyValue && value < 0 || _currencyValue > _endCurrencyValue && value > 0)
                _currencyValue = _endCurrencyValue;

            _wallet.UpdateCurrency(rewards, _currencyValue);
            yield return null;
        }

        if (!changeOnlyText)
            _wallet.AddCurrency(rewards, value);

        ResetTimer();
    }

    private void ResetTimer()
    {
        _timerValue = 0;
    }
}
