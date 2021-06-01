using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using kcp2k;


namespace Matchmaker
{

    public class AutoHostClient : MonoBehaviour
    {
        [Header("Port")]
        public int PortCustom;

        [SerializeField] NetworkManager networkManager;

        public bool isLoading = false;

        public void Start()
        {
            isLoading = true;
            PortCustom = GlobalVariables.MatchData.Port;
            if (!Application.isBatchMode)
            { 
                Debug.Log($"=== Client Build ===");
                StartCoroutine(DelayRoom(0));
            }
            else
            {
                Debug.Log($"=== Server Build ===");
            }
        }

        private void Update()
        {
            if (isLoading)
            {
                Debug.Log("Loading");
            }
        }

        public void JoinLocal()
        {
            networkManager.networkAddress = "localhost";
            networkManager.StartClient();
        }

        IEnumerator DelayRoom(float delay)
        {
            var Client = networkManager.transform.GetComponent<kcp2k.KcpTransport>();
            Client.Port = (ushort)(PortCustom);
            yield return new WaitForSeconds(delay);
            networkManager.StartClient();
            isLoading = false;
        }


    }
}
