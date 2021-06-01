using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class Player
{
    public string Name { get; set; }
    public string Level { get; set; }
    public NetworkConnection PlayerConn { get; set; }

    public static Player localPlayer;

    [SyncVar] public string matchID;
    [SyncVar] public int playerIndex;
}
