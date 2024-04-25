using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unite_humaine : Unite 
{
    private Vector3 destination; // La destination vers laquelle l'unité se déplace
    public void Deplacement(Vector3 destination)
    {
        // Calculer la direction vers la destination
        Vector3 direction = (destination - transform.position).normalized;

        // Déplacer l'unité
        transform.position = Vector3.MoveTowards(transform.position, destination, VitesseDeplacement * Time.deltaTime);
        Deplacer(transform.position.x, transform.position.y, transform.position.z);

        // Si l'unité n'est pas encore arrivée à destination
        if (transform.position != destination)
        {
            // Calculer la rotation vers la direction
            Quaternion rotation = Quaternion.LookRotation(direction);
            // Interpoler entre la rotation actuelle et la rotation vers la direction
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5*Time.deltaTime);
        }

        // Si l'unité a atteint sa destination
        if (transform.position == destination)
        {
            IsWalking = false; // Arrêter le déplacement
        }
    }

    protected override void Update()
    {   
        if (Input.GetMouseButton(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            int terrainLayerMask = 1 << LayerMask.NameToLayer("Terrain"); // Crée un masque pour le layer "Terrain"
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, terrainLayerMask)) // Utilise le masque pour filtrer les collisions
            {
                destination = hit.point; 
                destination.y = 0;
                IsWalking = true;
            }
        }

        // On autorise le déplacement uniquement si on n'est pas en train de tirer
        if (IsWalking && !en_position_pour_tirer)
        {
            Deplacement(destination); 
        }

        ///Ici on veut permettre à l'utilisateur de cliquer pour changer son orientation avant d'envoyer son projectile
        ///Bien qu'il ne puisse pas bouger
        if(en_position_pour_tirer)
        {
            Vector3 direction = (destination - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, 5*Time.deltaTime);
        }

        if(UnityEngine.Input.GetKeyDown(KeyCode.T))
        {
            Tir();
        }

        base.Update();
    }

}
