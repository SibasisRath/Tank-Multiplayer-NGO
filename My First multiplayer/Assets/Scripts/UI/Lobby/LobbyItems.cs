using TMPro;
using Unity.Services.Lobbies.Models;
using UnityEngine;

public class LobbyItems : MonoBehaviour
{
    [SerializeField] private TMP_Text lobbyName;
    [SerializeField] private TMP_Text lobbyPlayerCount;

    private LobbiesList lobbyList;
    private Lobby lobby;

    public void Initialize(LobbiesList lobbiesList, Lobby lobby)
    {
        this.lobby = lobby;
        this.lobbyList = lobbiesList;
        lobbyName.text = lobby.Name;
        lobbyPlayerCount.text = $"{lobby.Players.Count}/{lobby.MaxPlayers}";
    }

    public void Join()
    {
        lobbyList.JoinAsync(lobby);
    }
}
