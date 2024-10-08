using System.Collections;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private float lifeTimeDuration = 1f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(lifeTimeDuration);
        Destroy(this.gameObject);
    }
}
