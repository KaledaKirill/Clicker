using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupPresenter : IPresenter
{
    PopupModel _popupModel;
    PopupView _popupView;

    public PopupPresenter(PopupModel popupModel,  PopupView popupView)
    {
        _popupModel = popupModel;
        _popupView = popupView;
    }

    public void Disable()
    {
        //_popupModel.BoostValueChanged += 
    }

    public void Enable()
    {
        throw new System.NotImplementedException();
    }
}
