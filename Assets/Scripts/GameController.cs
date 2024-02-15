using UnityEngine;

public class GameController : MonoBehaviour
{
    private ClickerScreenModel _clickerModel;
    private ClickerScreenView _clickerView;
    private ClickerScreenPresenter _clickerPresenter;

    void Start()
    {
        _clickerModel = new ClickerScreenModel();

        var prefab = Resources.Load<ClickerScreenView>(nameof(ClickerScreenView));
        _clickerView = Object.Instantiate<ClickerScreenView>(prefab, Vector3.zero, Quaternion.identity);

        _clickerPresenter = new ClickerScreenPresenter(_clickerView, _clickerModel);
    }
}