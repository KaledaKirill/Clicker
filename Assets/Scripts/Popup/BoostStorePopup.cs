using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEngine.EventSystems.EventTrigger;

public class BoostStorePopup : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private Button hideButton;
    [SerializeField] private Button coinsPerClickBuyButton;
    [SerializeField] private Button EnergyBuyButton;
    [SerializeField] private Button RechargeTimeBuyButton;

    [Header("Description text")]
    [SerializeField] private TextMeshProUGUI coinsPerClickDescriptionText;
    [SerializeField] private TextMeshProUGUI EnergyDescriptionText;
    [SerializeField] private TextMeshProUGUI RechargeTimeDescriptionText;

    [Header("Cost text")]
    [SerializeField] private TextMeshProUGUI coinsPerClickCostText;
    [SerializeField] private TextMeshProUGUI EnergyCostText;
    [SerializeField] private TextMeshProUGUI RechargeTimeCostText;

    private BoostService _boostService;
    private BoostType _boostType;
    
    [Inject]
    public void Construct(BoostService boostService, BoostType boostType)
    {
        _boostService = boostService;
        _boostType = boostType;
        SetDescription(_boostService.GetCoinsPerClick, _boostService.GetCoinsPerClickCost);
    }

    private void Awake()
    {
        SetUpListeners();
    }

    private void SetUpListeners()
    {
        hideButton.onClick.AddListener(HidePopup);
        coinsPerClickBuyButton.onClick.AddListener(OnBuyButtonClicked);
    }

    private void RemoveListeners()
    {
        hideButton.onClick.RemoveAllListeners();
        coinsPerClickBuyButton.onClick.RemoveAllListeners();
    }

    public void HidePopup()
    {
        RemoveListeners();
        Destroy(gameObject);
    }

    public void SetDescription(int boostValue, int costValue)
    {
        coinsPerClickDescriptionText.text = boostValue + " coins per click";
        coinsPerClickCostText.text = costValue + "$";
    }

    private void OnBuyButtonClicked()
    {
        _boostService.BoostCoinsPerClick();
        SetDescription(_boostService.GetCoinsPerClick, _boostService.GetCoinsPerClickCost);
    }

    public class Factory : PlaceholderFactory<BoostStorePopup> { }
}