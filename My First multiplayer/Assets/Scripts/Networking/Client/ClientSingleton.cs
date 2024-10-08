using System.Threading.Tasks;
using UnityEngine;

public class ClientSingleton : MonoBehaviour
{
    private static ClientSingleton instance;

    public ClientGameManager ClientGameManager {  get; private set; }

    public static ClientSingleton Instance 
    {
        get 
        {
            if (instance != null)
            {
                return instance;
            }
            instance = FindObjectOfType<ClientSingleton>();
            if(instance == null) 
            {
                Debug.Log("No client singleton in the scene.");
            }
            return instance;
        }
    }
    private void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    public async Task<bool> CreateClient()
    {
        ClientGameManager = new ();
        return await ClientGameManager.InitAsync();
    }

    private void OnDestroy()
    {
        ClientGameManager?.Dispose();
    }
}
