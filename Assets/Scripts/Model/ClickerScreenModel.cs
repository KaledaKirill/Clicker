using System;
using System.Timers;
using Unity.VisualScripting;

public class ClickerScreenModel
{
    public event Action CountChanged;
    public event Action EnergyCountChanged;
    public event Action EnergyEnd;
    public event Action TimeChanged;
    public event Action TimeIsOver;


    private int _coinsCount;
    private int _coinsPerClick = 10;
    private int _minCoinsCount = 0;
    private int _maxEnergy = 100;
    private int _energyCount;
    private int _rechargeTime = 10;
    private int _currentTime;
    private static System.Timers.Timer _timer;

    public void SetCoinsCount(int count)
    { 
        _coinsCount = count;
        UpdateCount();
    }

    public void SetEnergyCount(int count)
    {
        _energyCount = count;
        UpdateEnergyCount();
    }

    public void SetCoinsPerClick(int count)
    {
        _coinsPerClick = count;    
        UpdateCount();
    }

    public void SetMaxEnergy(int count)
    {
        _maxEnergy = count;
        UpdateEnergyCount();
    }

    public void SetCurrentTime(int seconds)
    {
        _currentTime = seconds;
        TimeChanged?.Invoke();
    }

    public void SetRechargeTime(int seconds)
    {
        _rechargeTime = seconds;
    }

    public int GetCoinsCount() => _coinsCount;

    public int GetMinCoinsCount() => _minCoinsCount;

    public int GetCoinsPerClick() => _coinsPerClick;

    public int GetEnergyCount() => _energyCount;

    public int GetMaxEnergyCount() => _maxEnergy;

    public int GetRechargeTime() => _rechargeTime;

    public int GetCurrentTime() => _currentTime;


    public void DecrementEnergyCount(int count)
    {
        if (_energyCount <= _coinsPerClick)
        {
            EnergyEnd?.Invoke();
        }

        _energyCount -= count;
        UpdateEnergyCount();
    }

    public void RestartEnergy()
    {
        _energyCount = _maxEnergy;
        UpdateEnergyCount();
    }

    public void AddCount(int count)
    {
        _coinsCount += count;
        UpdateCount();
    }

    public void StartTimer()
    {
        _timer = new System.Timers.Timer(1000);
        _timer.Elapsed += TimerElapsed;
        _timer.Enabled = true;
    }

    private void TimerElapsed(object sender, ElapsedEventArgs e)
    {
        _currentTime -= 1;
        if (_currentTime == 0)
        {
            _timer.Elapsed -= TimerElapsed;
            _timer.Enabled = false;
            TimeIsOver?.Invoke();
        }
        TimeChanged?.Invoke();
    }

    public void UpdateCount()
    {
        CountChanged?.Invoke();
    }

    public void UpdateEnergyCount()
    {
        EnergyCountChanged?.Invoke();
    }
}