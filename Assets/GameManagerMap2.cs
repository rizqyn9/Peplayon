using Peplayon;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerMap2 : MonoBehaviour
{
    [SerializeField]
    private Transform[] spawnPlayer;

    private void Awake()
    {
        for (int i = 0; i < spawnPlayer.Length; i++)
        {
            //NetworkManagerPong.instance.spawnplayer[i] = spawnPlayer[i];
        }
    }
}