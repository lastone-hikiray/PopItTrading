using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//This class is a wrapper for animationEvents from all the hand animations
//These Events will be called when the hand 3d model Touthes buttons model

[RequireComponent(typeof(Animator))]
public class HandAnimationEvents : MonoBehaviour
{
    public event Action RiseButtonTouched;
    public event Action TradeButtonTouched;
    public event Action TradeFailButtonTouched;

    private void RiseButtonPress()
    {
        RiseButtonTouched?.Invoke();
    }

    private void TradeButtonPress()
    {
        TradeButtonTouched?.Invoke();
    }

    private void TradeFailButtonPress()
    {
        TradeFailButtonTouched?.Invoke();
    }

}