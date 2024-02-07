using UnityEngine;

public class GameController : MonoBehaviour
{
    private ClickerModel _clickerModel;
    private ClickerView _clickerView;
    private ClickerPresenter _clickerPresenter;

    void Start()
    {
        _clickerModel = new ClickerModel();

        var prefab = Resources.Load<ClickerView>(nameof(ClickerView));
        _clickerView = Object.Instantiate<ClickerView>(prefab, Vector3.zero, Quaternion.identity);

        _clickerPresenter = new ClickerPresenter(_clickerView, _clickerModel, _clickerView.CoinView);
    }
}