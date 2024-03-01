using System;

public class EnergyBoost : IBoost
{
    private int _cost = 150;
    private int _value = 100;
    private string _description = "energy";
    private float _boostMultiplier = 1.5f;

    public void BuyBoost()
    {
        _value = (int)(_value * _boostMultiplier);
    }

    public int GetBoostCost() => _cost;

    public string GetBoostDescription() => _description;

    public int GetBoostValue() => _value;

}