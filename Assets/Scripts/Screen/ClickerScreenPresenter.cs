using System.Drawing;
using System.Numerics;
using Unity.VisualScripting;


public class ClickerScreenPresenter : IPresenter
{
    ClickerScreenView _clickerScreenView;
    ClickerScreenModel _clickerScreenModel;
    PopupHub _popupHub;

    public ClickerScreenPresenter(ClickerScreenView clickerScreenView, ClickerScreenModel clickerModel, PopupHub popupHub)
    {
        _clickerScreenModel = clickerModel;
        _clickerScreenView = clickerScreenView;
        _popupHub = popupHub;
        Enable();

        _clickerScreenView.SetEnergySliderMaxValue(_clickerScreenModel.GetMaxEnergyCount());
        _clickerScreenModel.SetCoinsCount(_clickerScreenModel.GetMinCoinsCount());
        _clickerScreenModel.SetEnergyCount(_clickerScreenModel.GetMaxEnergyCount());
        _clickerScreenModel.SetCurrentTime(_clickerScreenModel.GetRechargeTime());
        DisableRestartEnergyButton();
    }

    public void Enable()
    {
        _clickerScreenModel.CountChanged += OnViewChanged;
        _clickerScreenView.CoinClicked += UpdateCoinsCount;
        _clickerScreenView.CoinClicked += UpdateEnergyCount;
        _clickerScreenModel.EnergyCountChanged += OnViewChanged;
        _clickerScreenModel.EnergyEnd += OnEnergyEnd;
        _clickerScreenModel.TimeIsOver += EnableRestartEnergyButton;
        _clickerScreenView.EnergyButtonClick += RestartEnergy;
        _clickerScreenView.StoreButtonClick += CreateBoostStorePopup;
        _clickerScreenModel.MaxEnergyChanged += OnViewChanged;
    }
    public void Disable()
    {
        _clickerScreenModel.CountChanged -= OnViewChanged;
        _clickerScreenView.CoinClicked -= UpdateCoinsCount;
        _clickerScreenView.CoinClicked -= UpdateEnergyCount;
        _clickerScreenView.EnergyButtonClick -= RestartEnergy;
        _clickerScreenModel.EnergyCountChanged -= OnViewChanged;
        _clickerScreenModel.EnergyEnd -= OnEnergyEnd;
        _clickerScreenModel.TimeIsOver -= EnableRestartEnergyButton;
        _clickerScreenView.EnergyButtonClick -= RestartEnergy;
        _clickerScreenView.StoreButtonClick -= CreateBoostStorePopup;
    }

    private void UpdateCoinsCount() =>
        _clickerScreenModel.AddCount(_clickerScreenModel.GetCoinsPerClick());

    private void UpdateEnergyCount() => 
        _clickerScreenModel.DecrementEnergyCount(_clickerScreenModel.GetCoinsPerClick());

    private void UpdateView()
    {
        _clickerScreenView.SetScoreText(_clickerScreenModel.GetCoinsCount().ToString());
        _clickerScreenView.SetEnergyCountText(_clickerScreenModel.GetEnergyCount().ToString());
        _clickerScreenView.UpdateEnergySlider(_clickerScreenModel.GetEnergyCount());
        _clickerScreenView.SetEnergySliderMaxValue(_clickerScreenModel.GetMaxEnergyCount());
    }

    private void DisableCoin()
    {
        _clickerScreenView.CoinClicked -= UpdateCoinsCount;
        _clickerScreenView.CoinClicked -= UpdateEnergyCount;;
    }

    private void EnableCoin()
    {
        _clickerScreenView.CoinClicked += UpdateCoinsCount;
        _clickerScreenView.CoinClicked += UpdateEnergyCount;
    }

    private void RestartEnergy()
    {
        EnableCoin();
        _clickerScreenModel.RestartEnergy();
        _clickerScreenModel.SetCurrentTime(_clickerScreenModel.GetRechargeTime());
        DisableRestartEnergyButton();
    }

    private void CreateBoostStorePopup()
    {
        _popupHub.CreateBoostStorePopup();
    }

    private void DisableRestartEnergyButton()
    {
        _clickerScreenView.EnergyButtonClick -= RestartEnergy;
        //_clickerScreenView.HideEnergyButton();
    }
    private void EnableRestartEnergyButton()
    {
        _clickerScreenView.EnergyButtonClick += RestartEnergy;
        //_clickerScreenView.ShowEnergyButton();
    }

    private void OnEnergyEnd()
    {
        DisableCoin();
        _clickerScreenModel.StartTimer();
    }

    private void OnViewChanged() => 
        UpdateView();
}