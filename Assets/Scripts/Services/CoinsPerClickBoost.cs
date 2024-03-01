using System;

public class CoinsPerClickBoost : IBoost
{
    private int _cost = 70;
    private int _value = 1;
    private string _description = "coins per click";
    private float _boostMultiplier = 1.5f;

    public void BuyBoost()
    {
        _value = (int)(_value * _boostMultiplier);
    }

    public int GetBoostCost() => _cost;

    public string GetBoostDescription() => _description;

    public int GetBoostValue() => _value;
}