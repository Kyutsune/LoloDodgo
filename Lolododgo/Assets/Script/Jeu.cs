using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    private Unite_humaine unite_test;

    void Start()
    {
        unite_test = gameObject.AddComponent<Unite_humaine>();
        unite_test.Initialisation(0, 0, 0, 100, 10, 10, 5);
    }

    void Update()
    {
        
    }
}
