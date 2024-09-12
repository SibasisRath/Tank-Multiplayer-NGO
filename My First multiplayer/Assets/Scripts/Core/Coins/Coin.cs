using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public abstract class Coin : NetworkBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    protected int coinValue = 10;
    protected bool coinCollected;

    public abstract int Collect();

    public void SetValue(int value)
    {
    coinValue = value; 
    }

    protected void Show(bool value)
    {
        spriteRenderer.enabled = value;
    }
}
