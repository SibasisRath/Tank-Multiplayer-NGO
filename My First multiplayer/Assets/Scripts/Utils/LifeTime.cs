using System.Collections;
using UnityEngine;

public class LifeTime : MonoBehaviour
{
    [SerializeField] private float lifeTimeDuration = 1f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(lifeTimeDuration);
        Debug.Log("destroyed due to time up.");
        //Destroy(gameObject, lifeTimeDuration);
        Destroy(this.gameObject);
    }
}
