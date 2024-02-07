using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ClickerView : MonoBehaviour
{
    public event Action OnClick;

    public TextMeshProUGUI ScoreText;
    public CoinView CoinView;
    public TextMeshProUGUI EnergyCountText;

    public void OnCLick()
    {
        OnClick?.Invoke();
    }
}