using System;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class NetworkServer : IDisposable
{
    private NetworkManager networkManager;

    public Action<string> OnClientLeft;

    private Dictionary<ulong, string> clientIdToAuth = new ();
    private Dictionary<string, UserData> authIdToUserData = new ();
    public NetworkServer(NetworkManager networkManager) 
    {
        this.networkManager = networkManager;
        networkManager.ConnectionApprovalCallback += AprovalCheck;
        networkManager.OnServerStarted += OnNetworkReady;
    }

    private void OnNetworkReady()
    {
        networkManager.OnClientDisconnectCallback += OnClientDisconnect;
    }

    private void OnClientDisconnect(ulong clientId)
    {
        if (clientIdToAuth.TryGetValue(clientId, out string authId)) 
        {
            clientIdToAuth.Remove(clientId);
            authIdToUserData.Remove(authId);
            OnClientLeft?.Invoke(authId);
        }
    }

    private void AprovalCheck(
        NetworkManager.ConnectionApprovalRequest request,
        NetworkManager.ConnectionApprovalResponse response)
    {
        string payload = System.Text.Encoding.UTF8.GetString(request.Payload);
        UserData userData = JsonUtility.FromJson<UserData>(payload);

        clientIdToAuth[request.ClientNetworkId] = userData.userAuthId;
        authIdToUserData[userData.userAuthId] = userData;

        response.Approved = true;
        response.Position = SpawnPoint.GetRandomSpawnPos();
        response.Rotation = Quaternion.identity;
        response.CreatePlayerObject = true;
    }

    public UserData GetUserDataByClientId(ulong clientId) 
    {
        if (clientIdToAuth.TryGetValue(clientId, out string authId))
        {
            if (authIdToUserData.TryGetValue(authId, out UserData userData)) 
            {
                return userData;
            }
            return null;
        }
        return null;
    }

    public void Dispose()
    {
        if (networkManager != null)
        {
            networkManager.ConnectionApprovalCallback -= AprovalCheck;
            networkManager.OnServerStarted -= OnNetworkReady;
            networkManager.OnClientDisconnectCallback -= OnClientDisconnect;
        }
        if (networkManager.IsListening)
        {
            networkManager.Shutdown();
        }
    }
}
