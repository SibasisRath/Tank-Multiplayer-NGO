using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BountyCoin : Coin
{
    public override int Collect()
    {
        if (!IsServer)
        {
            Show(false);
            return 0;
        }

        if (coinCollected) { return 0; }

        coinCollected = true;

        Destroy(gameObject);

        return coinValue;
    }
}

