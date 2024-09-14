using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using Unity.Networking.Transport.Relay;
using Unity.Services.Authentication;
using Unity.Services.Lobbies;
using Unity.Services.Lobbies.Models;
using Unity.Services.Relay;
using Unity.Services.Relay.Models;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HostGameManager : IDisposable
{
    private Allocation allocation;
    private const int MaxConnections = 20;
    private const string GameSceneName = "Game";
    private const string ConnectionType = "dtls";
    private string joinCode;
    private string lobbyId;

    private NetworkServer networkServer;

    public async Task StartHostAsync()
    {
        try
        {
            allocation = await Relay.Instance.CreateAllocationAsync(MaxConnections);
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return;
        }

        try
        {
            joinCode = await Relay.Instance.GetJoinCodeAsync(allocation.AllocationId);
            Debug.Log(joinCode);
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return;
        }
        UnityTransport unityTransport = NetworkManager.Singleton.GetComponent<UnityTransport>();

        RelayServerData relayServerData = new(allocation, ConnectionType);
        unityTransport.SetRelayServerData(relayServerData);

        try
        {
            CreateLobbyOptions lobbyOptions = new CreateLobbyOptions();
            lobbyOptions.IsPrivate = false;
            lobbyOptions.Data = new Dictionary<string, DataObject>() 
            {
                {
                    "joinCode", new DataObject(visibility: DataObject.VisibilityOptions.Member, value: joinCode)
                }
            };
            string playerName = PlayerPrefs.GetString(NameSelection.playerNameKey, "Missing Name");
            Lobby lobby = await Lobbies.Instance.CreateLobbyAsync($"{playerName}'s Lobby", MaxConnections,lobbyOptions);
            lobbyId = lobby.Id;  
            
            HostSingleton.Instance.StartCoroutine(HearbeatLobby(15));
        }
        catch (LobbyServiceException e) 
        { 
            Debug.Log(e);
            return;
        }

        networkServer = new(NetworkManager.Singleton);

        UserData userData = new UserData
        {
            userName = PlayerPrefs.GetString(NameSelection.playerNameKey, "Missing Name"),
            userAuthId = AuthenticationService.Instance.PlayerId
        };

        string playLoad = JsonUtility.ToJson(userData);
        byte[] playLoadByte = Encoding.UTF8.GetBytes(playLoad);

        NetworkManager.Singleton.NetworkConfig.ConnectionData = playLoadByte;

        NetworkManager.Singleton.StartHost();

        NetworkManager.Singleton.SceneManager.LoadScene(GameSceneName, LoadSceneMode.Single);
    }

    private IEnumerator HearbeatLobby(float waitTimeSeconds)
    {
        WaitForSecondsRealtime delay = new WaitForSecondsRealtime(waitTimeSeconds);
        while (true)
        {
            Lobbies.Instance.SendHeartbeatPingAsync(lobbyId);
            yield return delay;
        }
    }

    public async void Dispose()
    {
        HostSingleton.Instance.StopCoroutine(nameof(HearbeatLobby));
        if (!string.IsNullOrEmpty(lobbyId))
        {
            try
            {
                await Lobbies.Instance.DeleteLobbyAsync(lobbyId);
            }
            catch (LobbyServiceException e)
            {
                Debug.LogException(e);
            }

            lobbyId = string.Empty;
        }
        networkServer?.Dispose();
    }
}
