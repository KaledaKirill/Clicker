using System;
using UnityEngine;
using Zenject;

public class PopupHub
{
    [Inject] readonly BoostStorePopup.Factory _boostStorePopupFactory;
    private EnergyBoost _energyBoost = new EnergyBoost();
    private CoinsPerClickBoost _coinsPerClickBoost = new CoinsPerClickBoost();
    private RechargeTimeBoost _rechargeTimeBoost = new RechargeTimeBoost();

    public class Factory : PlaceholderFactory<PopupHub> { }

    public void CreateBoostStorePopup()
    {
        _boostStorePopupFactory.Create(_energyBoost, _coinsPerClickBoost, _rechargeTimeBoost);
    }
}