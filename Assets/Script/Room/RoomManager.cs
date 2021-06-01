using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace NetworkPeplayon
{
    public class RoomManager : NetworkBehaviour
    {
        public static List<NetworkConnection> connList = new List<NetworkConnection>();
        //SyncList<NetworkConnection> syncConnList = new SyncList<NetworkConnection>();
        public SyncList<Player> PlayersInRoom = new SyncList<Player>();

        [SyncVar] public int playerRoomIndex = 0;

        private void Start()
        {
            //CmdTest();
        }

        //private void Update()
        //{
        //    if(KeyCode)
        //}


        public void AddList (NetworkConnection conn, Player _player)
        {
            connList.Add(conn);
            PlayersInRoom.Add(_player);
            //syncConnList.Add(conn);
            //CmdTest();
            Debug.Log($"Adding Player");
            Debug.Log($"Count Player Add list {PlayersInRoom.Count}");
            //Test();
            Debug.Log($"{playerRoomIndex++} Player");
        }

        public void Test()
        {
            foreach(NetworkConnection aConn in connList)
            {
                Debug.Log($"{aConn.connectionId} Conn ID");
            }

            Debug.Log($"COUNT {PlayersInRoom.Count.ToString()}");

            foreach(Player player in PlayersInRoom)
            {
                Debug.Log(player.Name);
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
