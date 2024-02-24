public class BoostService
{
    private int _coinsPerClick;

    public int GetCoinsPerClick => _coinsPerClick;
    public void SetCoinsPerClick()
    {
        _coinsPerClick = _coinsPerClick * 2;
    }
}