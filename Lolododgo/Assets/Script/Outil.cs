using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outil
{
    public static int Aleatoire(int min, int max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    public static float distanceUnite(Unite courante, Unite autreUnite){
        return Vector3.Distance(new Vector3(courante.Positionx, courante.Positiony, courante.Positionz), new Vector3(autreUnite.Positionx, autreUnite.Positiony, autreUnite.Positionz));
    }

}
