using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using Unity.Netcode;
using Unity.XR.OpenVR;
using UnityEngine;

public class PlayerNameDisplay : MonoBehaviour
{
    [SerializeField] private TankPlayer player;
    [SerializeField] private TMP_Text playerDisplayName;

    private void Start()
    {
        HandlePlayerNameChange(string.Empty, player.playerName.Value);


        player.playerName.OnValueChanged += HandlePlayerNameChange;
    }

    private void HandlePlayerNameChange(FixedString32Bytes oldName, FixedString32Bytes newName)
    {
        playerDisplayName.text = newName.ToString();
    }

    private void OnDestroy()
    {
        player.playerName.OnValueChanged -= HandlePlayerNameChange;
    }
}
