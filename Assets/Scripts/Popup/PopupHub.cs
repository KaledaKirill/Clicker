using UnityEngine;

public class PopupHub 
{
    private ClickerScreenView _clickerScreenView;

    public PopupHub(ClickerScreenView clickerScreenView)
    {
        _clickerScreenView = clickerScreenView;
        SetupHandlers();
    }

    private void SetupHandlers()
    {
        _clickerScreenView.StoreButtonClick += CreateBoostStorePopup;
    }

    private void CreateBoostStorePopup()
    {
        Creator creator = new BoostStorePopupCreator();
        IPopup boostStorePopup = creator.FactoryMethod(Vector3.zero);
    }
}