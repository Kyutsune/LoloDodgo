using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jeu : MonoBehaviour
{
    private Unite unite_test;
    private Gestion_prefab gestion_prefab;
    private GameObject corps_unite_test;
    private Controleur_Animation animator_controller;
    private Animator animator_unite_a_controller;

    void Start()
    {
        gestion_prefab = new Gestion_prefab();
        unite_test = gameObject.AddComponent<Unite>();
        unite_test.Initialisation(0, 0, 0, 100, 10, 10);
        corps_unite_test = gestion_prefab.CreerPrefab(unite_test.Positionx, unite_test.Positiony, unite_test.Positionz);
        animator_controller = gameObject.AddComponent<Controleur_Animation>();
        animator_unite_a_controller=corps_unite_test.GetComponent<Animator>();
    }

    void Update()
    {
        unite_test.GestionEvenement();
        gestion_prefab.DeplacerPrefab_a_partir_unite(corps_unite_test, unite_test);
        animator_controller.animation(unite_test, animator_unite_a_controller);
    }
}
