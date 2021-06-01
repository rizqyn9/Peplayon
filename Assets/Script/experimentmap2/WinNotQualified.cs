using Mirror;
using Peplayon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinNotQualified : NetworkBehaviour
{
    [SerializeField]
    private bool win;

    public GameObject lose, camera1;

    private void Update()
    {
        if (win)
        {
            ClientSetWin();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            win = true;
            ClientInstance cl = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ClientInstance>();
            NetworkIdentity player = other.GetComponent<NetworkIdentity>();
            NetworkIdentity item = GetComponent<NetworkIdentity>();
            Debug.Log("TriggerWin");
            cl.getauthority(item, player);
        }
    }

    public void ClientSetWin()
    {
        if (!hasAuthority) return;
        win = false;
        GameObject localplayer = ClientScene.localPlayer.gameObject;
        NetworkIdentity get = localplayer.GetComponent<NetworkIdentity>();
        string nm = get.netId.ToString();
        Debug.Log(nm);

        CMDWin(nm);
    }

    [Command]
    public void CMDWin(string kl)
    {
        CliensRPCsetWin(kl);
    }

    [ClientRpc]
    public void CliensRPCsetWin(string hj)
    {
        GameObject klkl = ClientScene.localPlayer.gameObject;
        NetworkIdentity ff = klkl.GetComponent<NetworkIdentity>();
        string hh = ff.netId.ToString();
        Debug.Log(hh);
        NetworkManagerPong.haha = false;

        if (hh == hj)
        {
            Debug.Log("Win");

            CharacterControls cr = GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterControls>();

            cr.lolos();
            StartCoroutine(LoadPodium());
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            camera1.SetActive(true);
            lose.SetActive(true);
            Debug.Log("kalah");
        }
    }

    private IEnumerator LoadPodium()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Podium");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}