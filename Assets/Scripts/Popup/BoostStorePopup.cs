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
    [SerializeField] private Button energyBuyButton;
    [SerializeField] private Button rechargeTimeBuyButton;

    [Header("Description text")]
    [SerializeField] private TextMeshProUGUI coinsPerClickDescriptionText;
    [SerializeField] private TextMeshProUGUI energyDescriptionText;
    [SerializeField] private TextMeshProUGUI rechargeTimeDescriptionText;

    [Header("Cost text")]
    [SerializeField] private TextMeshProUGUI coinsPerClickCostText;
    [SerializeField] private TextMeshProUGUI energyCostText;
    [SerializeField] private TextMeshProUGUI rechargeTimeCostText;

    private BoostService _boostService;
    private EnergyBoost _energyBoost; 
    private CoinsPerClickBoost _coinsPerClickBoost; 
    private RechargeTimeBoost _rechargeTimeBoost; 

    
    [Inject]
    public void Construct(
        BoostService boostService, 
        EnergyBoost energyBoost, 
        CoinsPerClickBoost coinsPerClickBoost, 
        RechargeTimeBoost rechargeTimeBoost
        )
    {
        _boostService = boostService;
        _coinsPerClickBoost = coinsPerClickBoost;
        _energyBoost = energyBoost;
        _rechargeTimeBoost = rechargeTimeBoost;
        SetUpListeners();
        SetDescription();
    }

    private void SetUpListeners()
    {
        hideButton.onClick.AddListener(HidePopup);
        coinsPerClickBuyButton.onClick.AddListener(() => BuyBoost(_coinsPerClickBoost));
        coinsPerClickBuyButton.onClick.AddListener(() => UpdateDescription(_coinsPerClickBoost,coinsPerClickCostText, coinsPerClickDescriptionText));
        energyBuyButton.onClick.AddListener(() => BuyBoost(_energyBoost));
        energyBuyButton.onClick.AddListener(() => UpdateDescription(_energyBoost, energyCostText, energyDescriptionText));
        rechargeTimeBuyButton.onClick.AddListener(() => BuyBoost(_rechargeTimeBoost));
        rechargeTimeBuyButton.onClick.AddListener(() => UpdateDescription(_rechargeTimeBoost, rechargeTimeCostText, rechargeTimeDescriptionText));
        
    }

    private void RemoveListeners()
    {
        hideButton.onClick.RemoveAllListeners();
        coinsPerClickBuyButton.onClick.RemoveAllListeners();
        energyBuyButton.onClick.RemoveAllListeners();
        rechargeTimeBuyButton.onClick.RemoveAllListeners();
    }

    public void HidePopup()
    {
        RemoveListeners();
        Destroy(gameObject);
    }

    public void UpdateDescription(IBoost boost, TextMeshProUGUI costTextField, TextMeshProUGUI descriptionTextField)
    {
        descriptionTextField.text = _boostService.GetDescription(boost);
        costTextField.text = _boostService.GetBoostCostText(boost);
    }

    public void SetDescription()
    {
        coinsPerClickDescriptionText.text = _boostService.GetDescription(_coinsPerClickBoost);
        energyDescriptionText.text = _boostService.GetDescription(_energyBoost);
        rechargeTimeDescriptionText.text = _boostService.GetDescription(_rechargeTimeBoost); 
        
        coinsPerClickCostText.text = _boostService.GetBoostCostText(_coinsPerClickBoost);
        energyCostText.text = _boostService.GetBoostCostText(_energyBoost);
        rechargeTimeCostText.text = _boostService.GetBoostCostText(_rechargeTimeBoost);
    }

    private void BuyBoost(IBoost boost)
    {
        _boostService.BuyBoost(boost);
    }

    public class Factory : PlaceholderFactory<EnergyBoost, CoinsPerClickBoost, RechargeTimeBoost, BoostStorePopup> { }
}