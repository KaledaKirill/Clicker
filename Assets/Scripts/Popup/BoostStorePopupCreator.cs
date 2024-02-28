using UnityEngine;
using Zenject;

public class BoostStorePopupCreator : Creator
{   
    public override IPopup FactoryMethod(Vector3 position)
    {
        var prefab = Resources.Load<BoostStorePopup>(nameof(BoostStorePopup));
        IPopup boostStorePopup = Object.Instantiate<BoostStorePopup>(prefab, Vector3.zero, Quaternion.identity);

        return boostStorePopup;
    }
}