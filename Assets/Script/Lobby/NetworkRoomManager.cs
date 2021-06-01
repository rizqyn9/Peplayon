using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using System.Linq;


namespace NetworkPeplayon
{
    public class PeplayonNetworkRoomManager : NetworkManager
    {
        [Header("Room Settings")]
        public int minPlayers = 10;
        public int maxPlayers = 40;


        public List<NetworkRoomManager> ListConn { get; } = new List<NetworkRoomManager>();
        public List<NetworkConnection> ListConnTes = new List<NetworkConnection>();

        public override void OnValidate()
        {
            Debug.Log("OnValidate");
            base.OnValidate();
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            //Debug.Log($"On Client Connect{conn.connectionId}");
            //Debug.Log($"On Client Connect{conn.isAuthenticated}");
            //Debug.Log($"On Client Connect{conn.lastMessageTime}");
            base.OnClientConnect(conn);
            Debug.Log("OnClientConnect");
        }


        public void Test ()
        {
            foreach(NetworkConnection conn in NetworkRoomManager.connList)
            {
                Debug.Log($"CONNECTION {conn.connectionId}");
            }
        }

        public override void OnClientDisconnect(NetworkConnection conn)
        {
            Debug.Log($"OnClientDisconnect {conn}");
            base.OnClientDisconnect(conn);
        }

        public override void OnServerConnect(NetworkConnection conn)
        {

            Debug.Log("New Client Connect to Server");
            base.OnServerConnect(conn);
        }

        public override void OnServerDisconnect(NetworkConnection conn)
        {
            Debug.Log($"OnServerDisconnect");
            base.OnServerDisconnect(conn);
        }

        public override void OnServerAddPlayer(NetworkConnection conn)
        {
            Debug.Log($"OnServerAddPlayer");
            base.OnServerAddPlayer(conn);
        }

        public override void OnClientChangeScene(string newSceneName, SceneOperation sceneOperation, bool customHandling)
        {
            Debug.Log($"On Client changed");
            base.OnClientChangeScene(newSceneName, sceneOperation, customHandling);
        }

        public override void OnClientSceneChanged(NetworkConnection conn)
        {
            Debug.Log($"OnClientSceneChanged");
            base.OnClientSceneChanged(conn);
        }

        public override void OnServerChangeScene(string newSceneName)
        {
            Debug.Log($"OnServerChangeScene");
            base.OnServerChangeScene(newSceneName);
        }

        public override void OnServerSceneChanged(string sceneName)
        {
            Debug.Log($"OnServerSceneChanged");
            base.OnServerSceneChanged(sceneName);
        }

        public override void OnStartClient()
        {
            NetworkIdentity id = playerPrefab.GetComponent<NetworkIdentity>();
            Debug.Log(id.assetId.ToString());
            Debug.Log($"OnStartClient");
            base.OnStartClient();
        }

        public override void OnStartHost()
        {

            Debug.Log($"OnStartHost");
            base.OnStartHost();
        }

        public override void OnServerReady(NetworkConnection conn)
        {
            Debug.Log($"OnServerReady");
            base.OnServerReady(conn);
        }

        public override void OnStartServer()
        {
            Debug.Log($"OnStartServer");
            base.OnStartServer();
        }

        public override void ServerChangeScene(string newSceneName)
        {
            Debug.Log($"ServerChangeScene");
            base.ServerChangeScene(newSceneName);
        }

        public override void OnStopClient()
        {
            Debug.Log($"OnStopClient");
            base.OnStopClient();
        }

        public override void OnStopHost()
        {
            Debug.Log($"OnStopHost");
            base.OnStopHost();
        }
        public override void OnStopServer()
        {
            Debug.Log($"OnStopServer");
            base.OnStopServer();
        }
    }
}
