using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupModel : MonoBehaviour
{
    public event Action CostChanged;
    public event Action BoostValueChanged;


    private int _cost;
    private int _boostValue;

    public void SetCost(int cost)
    { 
        _cost = cost;
        CostChanged?.Invoke();
    }

    public void SetBoostValue(int value)
    {
        _boostValue = value;
        BoostValueChanged?.Invoke();
    }

    public int GetCost() => _cost;
    public int GetBoostValue() => _boostValue;



}
