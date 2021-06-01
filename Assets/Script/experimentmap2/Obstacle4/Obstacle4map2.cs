using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle4map2 : MonoBehaviour
{
    public float jumpForce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody target = other.GetComponent<Rigidbody>();

            target.AddForce(Vector3.up * jumpForce);
        }
    }
}