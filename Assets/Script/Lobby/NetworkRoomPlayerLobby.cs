using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace NetworkPeplayon
{
    public class NetworkRoomPlayerLobby : NetworkBehaviour
    {
        public static NetworkRoomPlayerLobby localPlayer;
        [SyncVar] public string matchID;
        [SyncVar] public int playerIndex;

        [Header("Current Mach")]
        [SyncVar] public Match currentMatch;

        [SerializeField] public GameObject PlayerUIPrefab;
        [SerializeField] public Player playerDetails = new Player();
        [SerializeField] public PlayerDataSaved playerDataSaved = new PlayerDataSaved();

        public void Awake()
        {
            Debug.Log("Player == Awake");
        }

        public override void OnStartClient()
        {
            if (isLocalPlayer)
            {
                Debug.Log("Is Local Player");
                localPlayer = this;
            } else
            {
                Debug.Log($"Spawning other Player in this room");
            }

        }



    }
}

