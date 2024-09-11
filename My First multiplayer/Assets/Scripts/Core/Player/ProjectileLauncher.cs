using System;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

public class ProjectileLauncher : NetworkBehaviour
{
    [SerializeField] private InputReader inputReader;
    [SerializeField] private Transform ProjectileSpawnPoint;
    [SerializeField] private GameObject serverProjectilePrefab;
    [SerializeField] private GameObject clientProjectilePrefab;

    [SerializeField] private GameObject muzzleFlash;
    [SerializeField] private Collider2D playerColider;

    [SerializeField] private float projectileSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private float muzzleFlashDuration;

    private bool shouldFire;
    private float previousFireTime;
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
        if (!shouldFire) { return; }
        if (Time.time < (1/fireRate) + previousFireTime) { return; }
        PrimaryFireServerRpc(ProjectileSpawnPoint.position, ProjectileSpawnPoint.up);
        SpawnDummyProjectile(ProjectileSpawnPoint.position, ProjectileSpawnPoint.up);
        previousFireTime = Time.time;
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
        GameObject projectileInstance = Instantiate(
            serverProjectilePrefab,
            spawnPos,
            Quaternion.identity);
        projectileInstance.transform.up = dir;

        Physics2D.IgnoreCollision(playerColider, projectileInstance.GetComponent<Collider2D>());

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
