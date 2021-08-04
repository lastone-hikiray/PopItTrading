using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonAnimationsTrigger : MonoBehaviour
{
    [Header("Need a link from inspector")]
    [SerializeField] private Animator rise;
    [SerializeField] private Animator tradeFail;
    [SerializeField] private Animator trade;
    [SerializeField] private HandAnimationEvents handAnimationEvents;

    private void OnEnable()
    {
        handAnimationEvents.RiseButtonTouched += OnRiseButtonTouched;
        handAnimationEvents.TradeButtonTouched += OnTradeButtonTouched;
        handAnimationEvents.TradeFailButtonTouched += OnTradeFailButtonTouched;
    }

    private void OnDisable()
    {
        handAnimationEvents.RiseButtonTouched -= OnRiseButtonTouched;
        handAnimationEvents.TradeButtonTouched -= OnTradeButtonTouched;
        handAnimationEvents.TradeFailButtonTouched -= OnTradeFailButtonTouched;
    }

    private void OnRiseButtonTouched()
    {
        rise.SetTrigger(ButtonAnimator.PressButton);
    }
    private void OnTradeButtonTouched()
    {
        trade.SetTrigger(ButtonAnimator.PressButton);
    }

    private void OnTradeFailButtonTouched()
    {
        tradeFail.SetTrigger(ButtonAnimator.PressButton);
    }
}
