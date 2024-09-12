using Unity.Netcode;
using UnityEngine;

public class DealDamageOnContact : MonoBehaviour
{
    [SerializeField] private int damage = 5;

    private ulong clientPrivateId;

    public void SetOwner(ulong id) { this.clientPrivateId = id; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody == null) { return; }
        if (collision.attachedRigidbody.TryGetComponent<NetworkObject>(out NetworkObject obj)) 
        {
            if (clientPrivateId == obj.OwnerClientId) { return; }
        }
        Health health = collision.attachedRigidbody.GetComponent<Health>();
        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
}
