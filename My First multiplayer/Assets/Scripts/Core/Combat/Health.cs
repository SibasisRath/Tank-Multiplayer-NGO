using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class Health : NetworkBehaviour
{
    [field: SerializeField] public int maxHealth { get; private set; } = 100;
    public NetworkVariable<int> currentHealth = new ();

    private bool isDead;

    public Action<Health> OnDie;

    public override void OnNetworkSpawn()
    {
        isDead = false;
        if (!IsServer) { return; }
        currentHealth.Value = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        ModifyHealth(-damage);
    }

    public void RestoreHealth(int healAmount)
    {
        ModifyHealth(healAmount);
    }

    private void ModifyHealth(int modifyValue) 
    {
        if (isDead) { return; }
        int newHealth = currentHealth.Value + +modifyValue;
        currentHealth.Value = Mathf.Clamp(newHealth, 0, maxHealth);

        if (currentHealth.Value == 0 ) 
        {
            OnDie?.Invoke(this);
            isDead = true;
        }
    }
}
