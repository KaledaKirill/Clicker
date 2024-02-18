using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PopupView : MonoBehaviour
{
    public event Action BuyButtonClicked;

    [SerializeField] private Button buyButton;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI costText;

    private void Awake()
    {
        SetupListeners(BuyButtonClicked);
    }

    private void SetupListeners(Action buttonCLicked)
    {
        buyButton.onClick.AddListener(OnBuyButtonClick);
    }

    private void RemoveListeners()
    {
        buyButton.onClick.RemoveAllListeners();
    }

    public void SetDescriptionText(string text) =>
        descriptionText.text = text;

    public void SetCostText(string text) =>
        costText.text = text;

    private void OnBuyButtonClick() =>
        BuyButtonClicked?.Invoke();

}