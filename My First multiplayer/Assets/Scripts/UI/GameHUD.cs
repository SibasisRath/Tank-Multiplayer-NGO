using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameHUD : NetworkBehaviour
{
    [SerializeField] private TMP_Text joinCode;
     private bool gate = false;
    public override void OnNetworkSpawn()
    {
        /* Debug.Log("GameHUD Update called. Scene: " + SceneManager.GetActiveScene().buildIndex);

         // Check if we're in the correct scene (index 4) and gate is not yet set
         if (SceneManager.GetActiveScene().buildIndex == 3 && !gate)
         {
             gate = true;

             // Check if HostSingleton and hostGameManager are initialized
             if (HostSingleton.Instance == null)
             {
                 Debug.LogError("HostSingleton.Instance is null!");
                 return;
             }

             if (HostSingleton.Instance.hostGameManager == null)
             {
                 Debug.LogError("HostGameManager is not initialized!");
                 return;
             }

             // Fetch the join code and update the text
             string code = HostSingleton.Instance.hostGameManager.JoinCode;
             Debug.Log("Join code fetched: " + code);

             if (!string.IsNullOrEmpty(code))
             {
                 joinCode.text = code;
                 Debug.Log("Join code displayed: " + code);
             }
             else
             {
                 Debug.LogError("Join code is empty!");
             }
         }*/
        if (SceneManager.GetActiveScene().buildIndex == 3 && gate == false)
        {
            gate = true;
            string code = HostSingleton.Instance.hostGameManager.JoinCode;
            if (code != string.Empty)
            {
                joinCode.text = code;
            }
        }
    }
    public void LeaveGame()
    {
        if (NetworkManager.Singleton.IsHost)
        {
            HostSingleton.Instance.hostGameManager.Shutdown();
        }

        ClientSingleton.Instance.ClientGameManager.Disconnect();
    }

}
