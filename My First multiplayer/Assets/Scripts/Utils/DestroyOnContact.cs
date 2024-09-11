using UnityEngine;

public class DestroyOnContact : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("destroyed due to collision.");
        Destroy(this.gameObject);
    }
}
