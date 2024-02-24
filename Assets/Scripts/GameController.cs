using UnityEngine;

public class GameController : MonoBehaviour
{
    private ClickerScreenModel _clickerModel;
    private ClickerScreenView _clickerView;
    private ClickerScreenPresenter _clickerPresenter;
    private PopupHub _popupHub;

    void Start()
    {
        _clickerModel = new ClickerScreenModel();

        var clickerViewPrefab = Resources.Load<ClickerScreenView>(nameof(ClickerScreenView));
        _clickerView = Object.Instantiate<ClickerScreenView>(clickerViewPrefab, Vector3.zero, Quaternion.identity);

        _popupHub = new PopupHub(_clickerView);
        _clickerPresenter = new ClickerScreenPresenter(_clickerView, _clickerModel);
    }
}