using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float vie = 1;   

    void Awake()
    {
        Debug.Log("Projectile initialized.");
        Destroy(gameObject, vie);
    }

    void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        Destroy(gameObject);
    }
}
