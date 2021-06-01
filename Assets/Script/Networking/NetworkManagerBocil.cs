using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System;

namespace NetworkPeplayon
{
    [AddComponentMenu("")]
    public class NetworkManagerBocil : PeplayonNetworkRoomManager
    {
        public override void OnStartServer()
        {
            base.OnStartServer();
        }

        // List Players in Room
        public void PlayerJoin()
        {
            AddPlayer();
        }

        public void AddPlayer()
        {
            
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            base.OnClientConnect(conn);
        }
    }
}
