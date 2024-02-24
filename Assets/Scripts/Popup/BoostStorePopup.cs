using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BoostStorePopup : MonoBehaviour, IPopup
{
    public event Action BuyButtonClicked;

    [SerializeField] private Button buyButton;
    [SerializeField] private Button hideButton;
    [SerializeField] private TextMeshProUGUI descriptionText;
    private BoostService _boostService;

    private void SetUpListeners()
    {
        hideButton.onClick.AddListener(HidePopup);
        buyButton.onClick.AddListener(OnBuyButtonClicked);
    }

    private void RemoveListeners()
    {
        hideButton.onClick.RemoveAllListeners();
        buyButton.onClick.RemoveAllListeners();
    }

    private void Awake()
    {
        SetUpListeners();
    }

    public void HidePopup()
    {
        RemoveListeners();
        Destroy(gameObject);
    }

    private void OnBuyButtonClicked()
    {
        BuyButtonClicked?.Invoke();
    }
}