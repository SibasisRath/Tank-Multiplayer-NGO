using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CoinWallet : NetworkBehaviour
{
    [Header("References")]
    [SerializeField] private Health health;
    [SerializeField] private BountyCoin coinPrefab;

    [Header("Settings")]
    [SerializeField] private float coinSpread = 3f;
    [SerializeField] private float bountyPercentage = 50f;
    [SerializeField] private int bountyCoinCount = 10;
    [SerializeField] private int minBountyCoinValue = 5;
    [SerializeField] private LayerMask layerMask;

    private Collider2D[] coinBuffer = new Collider2D[1];
    private float coinRadius;
    public NetworkVariable<int> totalCoins = new NetworkVariable<int>();

    public void SpendCoins(int costToFire)
    {
        totalCoins.Value -= costToFire;
    }

    public override void OnNetworkSpawn()
    {
        if (!IsServer) { return; }

        coinRadius = coinPrefab.GetComponent<CircleCollider2D>().radius;

        health.OnDie += HandleDie;
    }

    public override void OnNetworkDespawn()
    {
        if (!IsServer) { return; }

        health.OnDie -= HandleDie;
    }
    private void HandleDie(Health health)
    {
        int bountyValue = (int)(totalCoins.Value * (bountyPercentage / 100f));
        int bountyCoinValue = bountyValue / bountyCoinCount;

        if (bountyCoinValue < minBountyCoinValue) { return; }

        for (int i = 0; i < bountyCoinCount; i++)
        {
            BountyCoin coinInstance = Instantiate(coinPrefab, GetSpawnPoint(), Quaternion.identity);
            coinInstance.SetValue(bountyCoinValue);
            coinInstance.NetworkObject.Spawn();
        }
    }

    private Vector2 GetSpawnPoint()
    {
        while (true)
        {
            Vector2 spawnPoint = (Vector2)transform.position + UnityEngine.Random.insideUnitCircle * coinSpread;
            int numColliders = Physics2D.OverlapCircleNonAlloc(spawnPoint, coinRadius, coinBuffer, layerMask);
            if (numColliders == 0)
            {
                return spawnPoint;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        int tempCoinValue = 0;
        if (!collision.gameObject.TryGetComponent<Coin>(out Coin coin)) { return; }
        tempCoinValue = coin.Collect();
        if (!IsServer) { return; }
        totalCoins.Value += tempCoinValue;
    }
}
