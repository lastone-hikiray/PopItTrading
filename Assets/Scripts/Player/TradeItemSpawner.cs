using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// the player and the bot have their own itemSpawner
public class TradeItemSpawner : MonoBehaviour
{
    [SerializeField] private Transform spawnPoint;

    [Header("Items Thorw Speed Range")]
    [SerializeField] private float minSpeed;
    [SerializeField] private float maxSpeed;

    [Header("Side Range")]
    [SerializeField] private float distanse;

    public event Action AddedItemInGame;

    public void SpawnItem(TradeItem template)
    {
        TradeItem newtradeItem = InstntiateNewItem(template);
        ThrowOnPlatform(newtradeItem);
        AddedItemInGame?.Invoke();
    }

    private TradeItem InstntiateNewItem(TradeItem template)
    {
        Vector3 spawnPosition = spawnPoint.position;
        spawnPosition.x += UnityEngine.Random.Range(-distanse, distanse);
        return Instantiate(template, spawnPosition, Quaternion.identity);
    }

    private void ThrowOnPlatform(TradeItem item)
    {
        Rigidbody rb = item.GetRigidbody();
        float speed = UnityEngine.Random.Range(minSpeed, maxSpeed);
        Vector3 direction = spawnPoint.forward;
        rb.velocity = direction * speed;
    }
}

