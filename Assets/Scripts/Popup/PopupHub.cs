using System;
using UnityEngine;
using Zenject;

public class PopupHub
{
    [Inject] readonly BoostStorePopup.Factory _boostStorePopupFactory;

    public class Factory : PlaceholderFactory<PopupHub> { }

    public void CreateBoostStorePopup()
    {
        //Creator creator = new BoostStorePopupCreator();
        //var prefab = Resources.Load<BoostStorePopup>(nameof(BoostStorePopup));
        //_diContainer.InstantiatePrefab(prefab, Vector3.zero, Quaternion.identity, null);
        //IPopup boostStorePopup = creator.FactoryMethod(Vector3.zero);
        _boostStorePopupFactory.Create();
    }
}