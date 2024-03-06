using System;

public class CoinsPerClickBoost : IBoost
{
    private int _cost = 70;
    private int _value = 1;
    private string _description = "coins per click";
    private float _boostMultiplier = 2f;
    private float _costMultiplier = 1.3f;

    public void BuyBoost()
    {
        _value = (int)(_value * _boostMultiplier);
        _cost = (int)(_cost * _costMultiplier);
    }

    public int GetBoostCost() => _cost;

    public string GetBoostDescription() => (int)(_value * _boostMultiplier) + " " + _description;

    public string GetBoostCostText() => _cost + "$";

    public int GetBoostValue() => _value;
}