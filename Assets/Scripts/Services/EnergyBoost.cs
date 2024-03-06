using System;

public class EnergyBoost : IBoost
{
    private int _cost = 150;
    private int _value = 100;
    private string _description = "energy";
    private float _boostMultiplier = 1.5f;
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