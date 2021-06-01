using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetDataUI : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI UserName;
    [SerializeField] TextMeshProUGUI Level;
    void Start()
    {
        UserName.text = PlayerPrefs.GetString("UserName");
        Level.text = PlayerPrefs.GetString("Level");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
