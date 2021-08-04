using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(TradeItemSpawner))]
public class Player : MonoBehaviour
{
    [SerializeField] private TradeItemSpawner itemsSpawner;
    
    [Header("Need a link from inspector")]
    [SerializeField] private Button rise;
    [SerializeField] private Button tradeFail;
    [SerializeField] private Button trade;
    [SerializeField] Animator hand;

    private void Reset()
    {
        itemsSpawner = GetComponent<TradeItemSpawner>();
    }

    private void OnEnable()
    {
        rise.onClick.AddListener(OnRiseButtonPress);
        trade.onClick.AddListener(OnTradeButtonPress);
        tradeFail.onClick.AddListener(OnTradeFailButtonPress);
    }

    private void OnDisable()
    {
        rise.onClick.RemoveListener(OnRiseButtonPress);
        trade.onClick.RemoveListener(OnTradeButtonPress);
        tradeFail.onClick.RemoveListener(OnTradeFailButtonPress);
    }

    private void OnRiseButtonPress()
    {
        hand.SetTrigger(HandAnimator.Rise);
    }
    private void OnTradeButtonPress()
    {
        hand.SetTrigger(HandAnimator.Trade);

    }
    private void OnTradeFailButtonPress()
    {
        hand.SetTrigger(HandAnimator.TradeFail);
    }
}
