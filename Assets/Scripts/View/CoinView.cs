using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CoinView : MonoBehaviour, IPointerClickHandler
{
    public event Action CoinClicked;
    public Slider EnergySlider;

    public void OnPointerClick(PointerEventData eventData)
    {
        CoinClicked?.Invoke();
    }
}
