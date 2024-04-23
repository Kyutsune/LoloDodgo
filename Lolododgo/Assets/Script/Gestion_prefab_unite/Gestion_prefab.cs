using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gestion_prefab 
{
    public GameObject CreerPrefab(float positionX, float positionY, float positionZ)
    {
        GameObject prefab_cube = Resources.Load<GameObject>("Prefab/Animation/Personnage_joueur_prefab");
        GameObject newUnite = GameObject.Instantiate(prefab_cube); 
        newUnite.name = "Notre_hero";
        newUnite.transform.position = new Vector3(positionX, positionY, positionZ);
        return(newUnite);
    }



    public void DetruirePrefab(GameObject objet)
    {
        GameObject.Destroy(objet);
    }

    public void DeplacerPrefab(GameObject objet, float positionX, float positionY, float positionZ)
    {
        objet.transform.position = new Vector3(positionX, positionY, positionZ);
    }

    public void DeplacerPrefab_a_partir_unite(GameObject objet, Unite unite)
    {
        objet.transform.position = new Vector3(unite.Positionx, unite.Positiony, unite.Positionz);
    }

}
