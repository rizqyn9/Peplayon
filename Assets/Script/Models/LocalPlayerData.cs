using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerDataSaved
{
    private string _id = "1";
    public string ID {
        get => _id;
        set
        {
            _id = value;
        }
    }
    private string _name = "Rizqy";
    public string Name {
        get => _name;
        set
        {
            _name = value;
        }
    }
    private int _level = 10;
    public int Level {
        get => _level;
        set
        {
            _level = value;
        }
    }
}

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

