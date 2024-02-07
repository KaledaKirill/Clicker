using System.Drawing;
using System.Numerics;
using Unity.VisualScripting;

public class ClickerPresenter : IPresenter
{
    ClickerView _clickerView;
    CoinView _coinView;
    ClickerModel _clickerModel;

    public ClickerPresenter(ClickerView clickerView, ClickerModel clickerModel, CoinView coinView)
    {
        _clickerModel = clickerModel;
        _clickerView = clickerView;
        _coinView = coinView;
        Enable();

        _coinView.EnergySlider.maxValue = _clickerModel.GetMaxEnergyCount();
        _clickerModel.SetCoinsCount(_clickerModel.GetMinCoinsCount());
        _clickerModel.SetEnergyCount(_clickerModel.GetMaxEnergyCount());
        _clickerModel.SetCurrentTime(_clickerModel.GetRechargeTime());
        DisableRestartEnergyButton();
    }

    public void Enable()
    {
        _clickerModel.CountChanged += OnViewChanged;
        _coinView.CoinClicked += UpdateEnergyCount;
        _coinView.CoinClicked += UpdateCoinsCount;
        _clickerModel.EnergyCountChanged += OnViewChanged;
        _clickerModel.EnergyEnd += OnEnergyEnd;
        _clickerModel.TimeIsOver += EnableRestartEnergyButton;
    }
    public void Disable()
    {
        _clickerModel.CountChanged -= OnViewChanged;
        _coinView.CoinClicked -= UpdateCoinsCount;
        _coinView.CoinClicked -= UpdateEnergyCount;
        _clickerView.OnClick -= RestartEnergy;
        _clickerModel.EnergyCountChanged -= OnViewChanged;
        _clickerModel.EnergyEnd -= OnEnergyEnd;
        _clickerModel.TimeIsOver -= EnableRestartEnergyButton;
    }

    private void UpdateCoinsCount()
    {
        _clickerModel.AddCount(_clickerModel.GetCoinsPerClick());
    }

    private void UpdateEnergyCount()
    {
        _clickerModel.DecrementEnergyCount(_clickerModel.GetCoinsPerClick());
    }

    private void UpdateView()
    {
        _clickerView.ScoreText.text = _clickerModel.GetCoinsCount().ToString();
        _clickerView.EnergyCountText.text = _clickerModel.GetEnergyCount().ToString();
        _coinView.EnergySlider.value = _clickerModel.GetEnergyCount();
    }

    private void DisableCoin()
    {
        _coinView.CoinClicked -= UpdateCoinsCount;
        _coinView.CoinClicked -= UpdateEnergyCount;;
    }

    private void EnableCoin()
    {
        _coinView.CoinClicked += UpdateCoinsCount;
        _coinView.CoinClicked += UpdateEnergyCount;
    }

    private void RestartEnergy()
    {
        EnableCoin();
        _clickerModel.RestartEnergy();
        _clickerModel.SetCurrentTime(_clickerModel.GetRechargeTime());
        DisableRestartEnergyButton();
    }

    private void DisableRestartEnergyButton()
    {
        _clickerView.OnClick -= RestartEnergy;
    }
    private void EnableRestartEnergyButton()
    {
        _clickerView.OnClick += RestartEnergy;
    }

    private void OnEnergyEnd()
    {
        DisableCoin();
        _clickerModel.StartTimer();
    }

    private void OnViewChanged()
    {
        UpdateView();
    }
}