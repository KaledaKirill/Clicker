using UnityEngine;
using Zenject;

public class Installer : MonoInstaller
{
    [SerializeField] private BoostStorePopup _boostStorePopupPrefab;
    public override void InstallBindings()
    {
        Container.Bind<BoostService>().AsSingle();
        Container.BindFactory<ClickerScreenModel, ClickerScreenModel.Factory>();
        Container.BindFactory<PopupHub, PopupHub.Factory>();
        Container.BindFactory<BoostStorePopup, BoostStorePopup.Factory>().FromComponentInNewPrefab(_boostStorePopupPrefab);
        Container.Bind<BoostType>().AsSingle().NonLazy();
    }
}