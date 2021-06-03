using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace NetworkPeplayon
{
    [System.Serializable]
    public class SyncListGameObject : SyncList<GameObject> { }

    [System.Serializable]
    public class SyncListMatch : SyncList<Match> { }

    [System.Serializable]
    public class Match
    {
        public string matchID;
        public bool publicMatch;
        public bool inMatch;
        public bool matchFull;
        public SyncListGameObject players = new SyncListGameObject();

        public Match(string matchID, GameObject player, bool publicMatch)
        {
            matchFull = false;
            inMatch = false;
            this.matchID = matchID;
            this.publicMatch = publicMatch;
            players.Add(player);
        }

        public Match() { }

    }

    public class NetworkRoomManager : NetworkBehaviour
    {
        [SyncVar] public int playerRoomIndex = 0;
        public SyncDictionary<string, NetworkIdentity> netID = new SyncDictionary<string, NetworkIdentity>();

        private PeplayonNetworkRoomManager networkRoomManager;
        private PeplayonNetworkRoomManager networkRoom
        {
            get
            {
                if (networkRoomManager != null) { return networkRoomManager; }
                return networkRoomManager = NetworkManager.singleton as PeplayonNetworkRoomManager;
            }
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UpdatePlayerRoomIndex();
                Debug.Log(playerRoomIndex);
            }
        }

        [Command]
        public void UpdatePlayerRoomIndex()
        {
           playerRoomIndex+=1;
        }

        private void Start()
        {
        }

        public override void OnStartClient()
        {
            Player player = GetComponent<Player>();
            UI_Lobby.instance.SpawnPlayerUIBillboard(player);
            networkRoom.RoomPlayers.Add(this);
            DontDestroyOnLoad(gameObject);
        }

        public void AddNetID(NetworkIdentity _netID)
        {
            Debug.Log("AddNetID");
            CmdAddNetID(_netID);
        } 

        [Command]
        public void CmdAddNetID(NetworkIdentity _netID)
        {
            Debug.Log("CmdAddNetID");
            netID.Add(_netID.assetId.ToString(), _netID);

        }


    }
}
