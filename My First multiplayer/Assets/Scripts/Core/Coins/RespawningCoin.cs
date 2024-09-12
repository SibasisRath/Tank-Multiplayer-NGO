using System;
using UnityEngine;

public class RespawningCoin : Coin
{
    public event Action<RespawningCoin> OnCoinCollected;

    private Vector3 previousPosition;
    public override int Collect()
    {
        if (!IsServer) { Show(false); return 0; }
        if (coinCollected) { return 0; }
        coinCollected = true;
        OnCoinCollected?.Invoke(this);
        return coinValue;
    }
    private void Update()
    {
        if (previousPosition != transform.position) { Show(true); }
        previousPosition = transform.position;
    }

    public void Reset()
    {
        coinCollected=false;
    }
}
