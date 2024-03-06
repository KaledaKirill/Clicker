using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private BoostStorePopup _boostStorePopupPrefab;
    public override void InstallBindings()
    {
        Container.Bind<BoostService>().AsSingle();
        Container.BindFactory<ClickerScreenModel, ClickerScreenModel.Factory>();
        Container.BindFactory<PopupHub, PopupHub.Factory>().NonLazy();
        Container.BindFactory<EnergyBoost, CoinsPerClickBoost, RechargeTimeBoost, BoostStorePopup, BoostStorePopup.Factory>().FromComponentInNewPrefab(_boostStorePopupPrefab);
    }
}