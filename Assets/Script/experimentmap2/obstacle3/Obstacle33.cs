using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle33 : MonoBehaviour
{
    public int index;
    public int indexList;
    public bool trap = false;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ooo");
        if (trap) SetTrap();
    }

    public void SetTrap()

    {
        LeanTween.moveLocalY(gameObject, -3.1f, 1);
    }
}