using System;
using UnityEngine;

public class BoostService
{ 
    public event Action<int> CoinsPerClickChanged;
    public event Action<int> BalanceChanged;
    public event Action<int> CostChanged;

    private int _coinsPerClick = 2;
    private int _coinsPerClickMultiplier = 2;
    private int _coinsPerClickCost = 50;
    private int _balance = 0;
    private float _cost_multiplier = 1.5f;

    public int GetCoinsPerClickCost => _coinsPerClickCost;

    public int GetCoinsPerClick => _coinsPerClick;

    public void SetCoinsPerClick(int value)
    {
        _coinsPerClick = value;
    }

    public void SetBalance(int value)
    {
        _balance = value;
    }

    public void BoostCoinsPerClick()
    {
        if (_balance >= _coinsPerClickCost)
        {
            _coinsPerClick = _coinsPerClick * _coinsPerClickMultiplier;
            CoinsPerClickChanged?.Invoke(_coinsPerClick);
            _balance -= _coinsPerClickCost;
            BalanceChanged?.Invoke(_balance);
            _coinsPerClickCost = (int)(_coinsPerClickCost * _cost_multiplier);
            CostChanged?.Invoke(_coinsPerClickCost);
        }
    }
}