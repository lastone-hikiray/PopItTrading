using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TradeItemSpawner))]
[RequireComponent(typeof(BotActor))]
public class BotAI : MonoBehaviour
{
    [SerializeField] private BotActor actor;
    [SerializeField] private TradeItem[] tradeItems;
    [SerializeField] private TradeItemSpawner itemSpawner;
    [SerializeField] private Animator hand;


    private int throwedItemsCount;

    private void Reset()
    {
        actor = GetComponent<BotActor>();
        itemSpawner = GetComponent<TradeItemSpawner>();
    }

    public void MakeAction(GameActions playerAction)
    {
        switch (playerAction)
        {
            case GameActions.ThrowItem:
                if (throwedItemsCount == 0)
                {
                    SpawnItem();
                }
                else
                {
                    PressTradeButton();
                }
                break;
            case GameActions.PressRise:
                if (ProfitableToSpawnItem())
                {
                    SpawnItem();
                }
                else
                {
                    PressRiseButton();
                }
                break;
            case GameActions.PressTrade:
                if (ProfitableToTrade())
                {
                    Trade();
                }
                else
                {
                    PressRiseButton();
                }
                break;
        }
    }

    private void PressTradeButton()
    {
        hand.SetTrigger(HandAnimator.Trade);
    }

    private void PressRiseButton()
    {
        hand.SetTrigger(HandAnimator.Trade);
    }

    private void Trade()
    {
        hand.SetTrigger(HandAnimator.Trade);
    }
    private void SpawnItem()
    {
        int index = UnityEngine.Random.Range(0, tradeItems.Length);
        itemSpawner.SpawnItem(tradeItems[index]);
    }
    private bool ProfitableToTrade()
    {
        throw new NotImplementedException();
    }

    private bool ProfitableToSpawnItem()
    {
        throw new NotImplementedException();
    }


}
