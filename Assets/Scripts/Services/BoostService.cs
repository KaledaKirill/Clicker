using System;
using UnityEngine;
using Zenject;

public class BoostService
{
    public event Action<int> BalanceChanged;
    public event Action<int> CoinsPerClickChanged;
    public event Action<int> EnergyChanged;
    public event Action<int> RechargeTimeChanged;


    private int _balance = 0;
    public void SetBalance(int value)
    {
        _balance = value;
    }

    public void BuyBoost(IBoost boost)
    {
        if(boost.GetBoostCost() <= _balance)
        {
            _balance -= boost.GetBoostCost();
            BalanceChanged?.Invoke(_balance);
            boost.BuyBoost();
        }

        ChooseAction(boost);
    }

    public string GetDescription(IBoost boost)
    {
        return boost.GetBoostDescription();
    }

    public string GetBoostCostText(IBoost boost)
    {
        return boost.GetBoostCostText();
    }

    private void ChooseAction(IBoost boost)
    {
        if (boost is CoinsPerClickBoost)
        {
            CoinsPerClickChanged?.Invoke(boost.GetBoostValue());
        }
        else if (boost is EnergyBoost)
        {
            EnergyChanged?.Invoke(boost.GetBoostValue());
        }
        else if (boost is RechargeTimeBoost)
        {
            RechargeTimeChanged?.Invoke(boost.GetBoostValue());
        }
    }
}