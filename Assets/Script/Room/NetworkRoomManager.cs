using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace NetworkPeplayon
{
    public class NetworkRoomManager : NetworkBehaviour
    {
        [SyncVar] public int playerRoomIndex = 0;

        private PeplayonNetworkRoomManager networkRoomManager;
        private PeplayonNetworkRoomManager networkRoom
        {
            get
            {
                if (networkRoomManager != null) { return networkRoomManager; }
                return networkRoomManager = NetworkManager.singleton as PeplayonNetworkRoomManager;
            }
        }

        private void Start()
        {
        }

        public override void OnStartClient()
        {
            DontDestroyOnLoad(gameObject);
        }

        //public void AddList (NetworkConnection conn)
        public void AddList (NetworkIdentity _net)
        {
        }
    }
}
