using System;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Core;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ClientGameManager : IDisposable
{
    private const string MenuSceneName = "Menu";

    private JoinAllocation joinAllocation;
    private NetworkClient networkClient;
    private const string ConnectionType = "dtls";


    public async Task<bool> InitAsync()
    {
        await UnityServices.InitializeAsync();

        networkClient = new(NetworkManager.Singleton);

        AuthStates authState = await AuthenticationWrapper.DoAuth();

        if (authState == AuthStates.Authenticated) { return true; }
        return false;
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene(MenuSceneName);
    }

    internal async Task StartClientAsync(string joinCode)
    {
        try
        {
            joinAllocation = await Relay.Instance.JoinAllocationAsync(joinCode);
        }
        catch (Exception e) 
        {
            Debug.LogError(e);
            return; 
        }
        UnityTransport unityTransport = NetworkManager.Singleton.GetComponent<UnityTransport>();

        RelayServerData relayServerData = new(joinAllocation, ConnectionType);
        unityTransport.SetRelayServerData(relayServerData);

        UserData userData = new UserData
        {
            userName = PlayerPrefs.GetString(NameSelection.playerNameKey, "Missing Name"),
            userAuthId = AuthenticationService.Instance.PlayerId
        };

        string playLoad = JsonUtility.ToJson(userData);
        byte[] playLoadByte = Encoding.UTF8.GetBytes(playLoad);

        NetworkManager.Singleton.NetworkConfig.ConnectionData = playLoadByte;

        NetworkManager.Singleton.StartClient();
    }

    public void Dispose()
    {
        networkClient?.Dispose();
    }
}
