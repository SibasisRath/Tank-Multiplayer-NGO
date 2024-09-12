using Unity.Netcode;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileLauncher : NetworkBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private CoinWallet wallet;
    [SerializeField] private Transform ProjectileSpawnPoint;
    [SerializeField] private GameObject serverProjectilePrefab;
    [SerializeField] private GameObject clientProjectilePrefab;

    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private Collider2D playerColider;

    [SerializeField] private float projectileSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private float muzzleFlashDuration;
    [SerializeField] private int costToFire;

    private bool shouldFire;
    private float timer;
    private float muzzleFlashTimmer;

    public override void OnNetworkSpawn()
    {
        if (!IsOwner) { return; }

        inputReader.PrimaryFireEvent += HandelPrimaryFire;
    }

    

    public override void OnNetworkDespawn()
    {
        if (!IsOwner) { return; }
        inputReader.PrimaryFireEvent -= HandelPrimaryFire;
    }

    // Update is called once per frame
    void Update()
    {
        if (muzzleFlashTimmer > 0f) 
        {
            muzzleFlashTimmer -= Time.deltaTime;
            if (muzzleFlashTimmer <= 0)
            {
                muzzleFlash.SetActive(false);
            }
        }
        if (!IsOwner) { return; }
        if (timer > 0) { timer -= Time.deltaTime; }
        
        if (!shouldFire) { return; }
        if (timer > 0) { return; }
        if (wallet.totalCoins.Value < costToFire) { return;}
        PrimaryFireServerRpc(ProjectileSpawnPoint.position, ProjectileSpawnPoint.up);
        SpawnDummyProjectile(ProjectileSpawnPoint.position, ProjectileSpawnPoint.up);
        timer = 1 / fireRate;
    }

    private void SpawnDummyProjectile(Vector3 position, Vector3 dir)
    {
        muzzleFlash.SetActive(true);
        muzzleFlashTimmer = muzzleFlashDuration;


        GameObject projectileInstance = Instantiate(
            clientProjectilePrefab,
            position,
            Quaternion.identity);
        projectileInstance.transform.up = dir;

        Physics2D.IgnoreCollision(playerColider, projectileInstance.GetComponent<Collider2D>());

        if (projectileInstance.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            rb.velocity = rb.transform.up * projectileSpeed;
        }
    }

    private void HandelPrimaryFire(bool shouldFire)
    {
        this.shouldFire = shouldFire;
    }

    [ServerRpc]
    private void PrimaryFireServerRpc(Vector3 spawnPos, Vector3 dir)
    {
        if (wallet.totalCoins.Value < costToFire) { return; }
        wallet.SpendCoins(costToFire);
        GameObject projectileInstance = Instantiate(
            serverProjectilePrefab,
            spawnPos,
            Quaternion.identity);
        projectileInstance.transform.up = dir;

        Physics2D.IgnoreCollision(playerColider, projectileInstance.GetComponent<Collider2D>());

        if (projectileInstance.TryGetComponent<DealDamageOnContact>(out DealDamageOnContact obj)) { obj.SetOwner(OwnerClientId); }

        if (projectileInstance.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
        {
            rb.velocity = rb.transform.up * projectileSpeed;
        }
        SpawnDummyProjectileClientRpc(spawnPos, dir);
    }

    [ClientRpc]
    private void SpawnDummyProjectileClientRpc(Vector3 spawnPos, Vector3 dir)
    {
        if (IsOwner) { return; }
        SpawnDummyProjectile(spawnPos,dir);
    }


}
