using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalPlayerData
{
    public string ID;
    public string Name;
    public int Level;

    public LocalPlayerData(string _id, string _name, int _level)
    {
        this.ID = _id;
        this.Name = _name;
        this.Level = _level;
    }
}

public class POST
{
    public string ID;
    public string Name;
    public string UserName;
    public string Password;


    public POST(string Name, string UserName, string Password, string ID = null)
    {
        this.ID = ID;
        this.Name = Name;
        this.UserName = UserName;
        this.Password = Password;
    }

    public string ToJSON()
    {
        return JsonUtility.ToJson(this);
    }
}
