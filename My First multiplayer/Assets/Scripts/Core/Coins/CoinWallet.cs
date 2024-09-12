using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class CoinWallet : NetworkBehaviour
{
    public NetworkVariable<int> totalCoins = new();

    public void SpendCoins(int costToFire)
    {
        totalCoins.Value -= costToFire;
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
