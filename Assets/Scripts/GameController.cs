using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    private ClickerScreenModel _clickerModel;
    private ClickerScreenView _clickerView;
    private ClickerScreenPresenter _clickerPresenter;
    private PopupHub _popupHub;
    [Inject] readonly ClickerScreenModel.Factory _clickerScreenModelFactory;
    [Inject] readonly PopupHub.Factory _popupHubFactory;


    void Start()
    {
        _clickerModel = _clickerScreenModelFactory.Create();

        var clickerViewPrefab = Resources.Load<ClickerScreenView>(nameof(ClickerScreenView));
        _clickerView = Object.Instantiate<ClickerScreenView>(clickerViewPrefab, Vector3.zero, Quaternion.identity);

        _popupHub = _popupHubFactory.Create();
        _clickerPresenter = new ClickerScreenPresenter(_clickerView, _clickerModel, _popupHub);
    }
}