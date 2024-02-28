using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickerScreenView : MonoBehaviour
{
    public event Action EnergyButtonClick;
    public event Action CoinClicked;
    public event Action StoreButtonClick;

    [SerializeField] private Slider energySlider;
    [SerializeField] private Button energyButton;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI energyCountText;
    [SerializeField] private Button coinButton;
    [SerializeField] private Button storeButton;


    private void SetupEventListeners(Action ButtonCLick)
    {
        energyButton.onClick.AddListener(OnEnergyButtonCLick);
        coinButton.onClick.AddListener(OnCoinClick);
        storeButton.onClick.AddListener(OnstoreButtonClick);
    }

    private void RemoveEventListeners() 
    {
        energyButton.onClick.RemoveAllListeners();
        coinButton.onClick.RemoveAllListeners();
        storeButton.onClick.RemoveAllListeners();
    }


    private void Awake()
    {
        SetupEventListeners(EnergyButtonClick);
    }

    private void OnstoreButtonClick()
    {
        StoreButtonClick?.Invoke();
    }

    private void OnEnergyButtonCLick() =>
        EnergyButtonClick?.Invoke();

    private void OnCoinClick() =>
        CoinClicked?.Invoke();

    public void SetScoreText(string text) =>
        scoreText.text = text;

    public void SetEnergyCountText(string text) =>
        energyCountText.text = text;

    public void UpdateEnergySlider(int value) =>
        energySlider.value = value;

    public void SetEnergySliderMaxValue(int value) =>
        energySlider.maxValue = value;

    public void ShowEnergyButton() =>
        energyButton.gameObject.SetActive(true);

    public void HideEnergyButton() =>
        energyButton.gameObject.SetActive(false);
}