using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle3map2 : MonoBehaviour
{
    [SerializeField]
    private List<Obstacle33> listOsbtacle3 = new List<Obstacle33>();

    public int randomvalue;
    private bool colapse;

    private void Start()
    {
        GameObject[] allObjectObstacle = UnityEngine.Object.FindObjectsOfType<GameObject>();

        foreach (GameObject go in allObjectObstacle)
        {
            if (go.CompareTag("obstacle3map2"))
            {
                Obstacle33 ob = go.GetComponent<Obstacle33>();
                if (ob.index == 1)
                {
                    listOsbtacle3.Add(ob);
                }
            }
        }
    }

    private void SetTrap()
    {
        for (int i = 0; i < listOsbtacle3.Count; i++)
        {
            BoxCollider obs = listOsbtacle3[i].gameObject.GetComponent<BoxCollider>();
            Debug.Log(listOsbtacle3[i]);
            randomvalue = UnityEngine.Random.Range(0, 2);
            if (randomvalue == 0)
            {
                listOsbtacle3[i].trap = true;
                /*listOsbtacle3[i].trap = true;
                listOsbtacle3[i].indexList = i;
                obs.isTrigger = true;*/

                Debug.Log("Set Trap");
            }
            else
            {
                Debug.Log("Not Trap");
            }
            Debug.Log(randomvalue);
        }
        Debug.Log(listOsbtacle3.Count);
    }

    private void Update()
    {
        if (!colapse)
        {
            SetTrap();
            colapse = true;
        }
    }
}