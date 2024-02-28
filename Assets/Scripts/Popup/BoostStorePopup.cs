using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.EventSystems.EventTrigger;

public class BoostStorePopup : MonoBehaviour
{
    [SerializeField] private Button buyButton;
    [SerializeField] private Button hideButton;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI costText;
    private BoostService _boostService;

    [Inject]
    public void Construct(BoostService boostService)
    {
        _boostService = boostService;
        SetDescription(_boostService.GetCoinsPerClick, _boostService.GetCoinsPerClickCost);
    }

    public class Factory : PlaceholderFactory<BoostStorePopup> { }

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

    public void SetDescription(int boostValue, int costValue)
    {
        descriptionText.text = boostValue + " coins per click";
        costText.text = costValue + "$";
    }

    private void OnBuyButtonClicked()
    {
        _boostService.BoostCoinsPerClick();
        SetDescription(_boostService.GetCoinsPerClick, _boostService.GetCoinsPerClickCost);
    }
}