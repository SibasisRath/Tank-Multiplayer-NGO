using System.Threading.Tasks;
using UnityEngine;

public class HostSingleton : MonoBehaviour
{
    private static HostSingleton instance;

    public HostGameManager hostGameManager;

    public static HostSingleton Instance 
    {
        get 
        {
            if (instance != null)
            {
                return instance;
            }
            instance = FindObjectOfType<HostSingleton>();
            if(instance == null) 
            {
                Debug.Log("No Host singleton in the scene.");
            }
            return instance;
        }
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void CreateHost()
    {
        hostGameManager = new ();
        //await hostGameManager.InitAsync();
    }
    private void OnDestroy()
    {
        hostGameManager?.Dispose();
    }
}
