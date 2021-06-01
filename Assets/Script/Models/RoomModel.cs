using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room
{
    public string Data;
    public string RoomID;
    public int Port;
    public bool IsPublic;
    public string[] PlayersInRoom;

    public Room(string _data,string _roomID, int _port, bool _isPublic, string[] _playersInRoom )
    {
        this.Data = _data;
        this.RoomID = _roomID;
        this.Port = _port;
        this.IsPublic = _isPublic;
        this.PlayersInRoom = _playersInRoom;
    }
}
