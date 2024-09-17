using System.Threading.Tasks;
using UnityEngine;

public class ApplicationController : MonoBehaviour
{
    [SerializeField] private ClientSingleton clientSingleton;
    [SerializeField] private HostSingleton hostSingleton;
    private async void Start()
    {
        DontDestroyOnLoad(gameObject);
        await LaunchInMode(SystemInfo.graphicsDeviceType == UnityEngine.Rendering.GraphicsDeviceType.Null);
    }

    private async Task LaunchInMode(bool isDedicatedServer) 
    {
        if (isDedicatedServer) { }
        else
        {
            HostSingleton hSingleton = Instantiate(hostSingleton);
            hSingleton.CreateHost();

            ClientSingleton cSingleton = Instantiate(clientSingleton);
            bool authenticated = await cSingleton.CreateClient();

           
            //go to main menu
            if (authenticated)
            {
                cSingleton.ClientGameManager.GoToMenu();
            }
        }
    }
}
