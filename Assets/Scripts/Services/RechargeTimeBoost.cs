using System;

public class RechargeTimeBoost : IBoost
{
    private int _cost = 200;
    private int _value = 10;
    private string _description = "seconds recharge";
    private float _boostDivider = 1.3f;

    public void BuyBoost()
    {
        _value = (int)(_value / _boostDivider);
    }

    public int GetBoostCost() => _cost;

    public string GetBoostDescription() => _description;

    public int GetBoostValue() => _value;
}