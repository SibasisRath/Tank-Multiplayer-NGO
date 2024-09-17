using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using Cinemachine;
using Unity.Collections;
using System;

public class TankPlayer : NetworkBehaviour
{
    [SerializeField] private CinemachineVirtualCamera cinemachine;
    [SerializeField] private SpriteRenderer miniMapIconRenderer;

    [SerializeField] private int cameraPriority = 15;
    [SerializeField] private Color ownerColor;

    [field:SerializeField] public Health Health {  get; private set; }
    [field: SerializeField] public CoinWallet Wallet { get; private set; }


    public NetworkVariable<FixedString32Bytes> playerName = new NetworkVariable<FixedString32Bytes>();

    public static event Action<TankPlayer> OnPlayerSpawned;
    public static event Action<TankPlayer> OnPlayerDespawned;


    public override void OnNetworkSpawn()
    {
        if (IsServer) 
        {
            UserData user =
                HostSingleton.Instance.hostGameManager.
                NetworkServer.GetUserDataByClientId(OwnerClientId);
            playerName.Value = user.userName;
            OnPlayerSpawned?.Invoke(this);
        }
        if (IsOwner) 
        { 
            cinemachine.Priority = cameraPriority;
            miniMapIconRenderer.color = ownerColor;
        }
    }
    public override void OnNetworkDespawn()
    {
        if (!IsServer)
        {
            return;
        }
        OnPlayerDespawned?.Invoke(this);
    }
}
