using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    private Unite unite_test;

    void Start()
    {
        unite_test = gameObject.AddComponent<Unite>();
        unite_test.Initialisation(0, 0, 0, 100, 10,10); 
    }

    void Update()
    {
        unite_test.GestionEvenement();
    }
}
