using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace NetworkPeplayon
{
    public class NetworkRoomManager : NetworkBehaviour
    {
        public static List<NetworkConnection> connList { get; } = new List<NetworkConnection>();
        //SyncList<NetworkConnection> syncConnList = new SyncList<NetworkConnection>();
        public SyncList<Player> PlayersInRoom = new SyncList<Player>();
        public SyncDictionary<string, Player> DictPlayersInRoom = new SyncDictionary<string, Player>();

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
            //CmdTest();
        }

        public override void OnStartClient()
        {
            DontDestroyOnLoad(gameObject);
            networkRoom.ListConn.Add(this);
            Test();
        }

        public void AddList (NetworkConnection conn)
        {
            //connList.Add(conn);
            //syncConnList.Add(conn);
            //CmdTest();
            //connList.Add(conn);
            Debug.Log($"Adding Player {conn.connectionId}");
            //Debug.Log($"Count Player Add list {PlayersInRoom.Count}");
            //Debug.Log($"{playerRoomIndex++} Player");
            //Test();
        }

        public void Test()
        {
            foreach(NetworkRoomManager net in networkRoom.ListConn)
            {         
                Debug.Log(net.netId.ToString());
            }
        }

        [Command]
        public void CmdTest()
        {
            Debug.Log("Cmd Test");
            ClientTest();
        }

        [ClientRpc]
        public void ClientTest()
        {
            foreach(NetworkConnection aconn in connList)
            {
                Debug.Log($"{aconn.ToString()} ========");
            }
        }
    }
}
