using Unity.Netcode;
using UnityEngine;

public class CoinSpawner : NetworkBehaviour
{
    [SerializeField] private RespawningCoin coinPrefab;
    [SerializeField] private int maxCoins = 50;
    [SerializeField] private int coinValue = 10;
    [SerializeField] private Vector2 xSpawnRange;
    [SerializeField] protected Vector2 ySpawnRange;

    [SerializeField] protected LayerMask layerMask;

    private float coinRadius;
    private Collider2D[] coinBuffer = new Collider2D[1];

    public override void OnNetworkSpawn()
    {
        if (!IsServer) { return; }

        coinRadius = coinPrefab.GetComponent<CircleCollider2D>().radius;
        for (int i = 0; i < maxCoins; i++) 
        {
            SpawnCoins();
        }
    }

    private void SpawnCoins()
    {
        RespawningCoin respawningCoin = Instantiate(coinPrefab, GetSpawnPoint(),Quaternion.identity);
        respawningCoin.SetValue(coinValue);
        respawningCoin.GetComponent<NetworkObject>().Spawn();
        respawningCoin.OnCoinCollected += HandelCoinCollected;
    }

    private void HandelCoinCollected(RespawningCoin coin)
    {
        coin.transform.position = GetSpawnPoint();
        coin.Reset();
    }

    private Vector2 GetSpawnPoint() 
    {
        float x = 0;
        float y = 0;
        while (true) 
        {
            x = Random.Range(xSpawnRange.x, xSpawnRange.y);
            y = Random.Range(ySpawnRange.x, ySpawnRange.y);
            Vector2 spawnPoint = new Vector2(x, y);
            int numCollider = Physics2D.OverlapCircleNonAlloc(spawnPoint,coinRadius,coinBuffer,layerMask);
            if (numCollider == 0)
            {
                return spawnPoint;
            }
        }
    }
 
}
