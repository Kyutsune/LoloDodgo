using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unite_humaine : Unite 
{
    public void Recuperation_valeurs_clic_souris()
    {
        float sourisx = 0f;
        float sourisy = 0f;
        float sourisz = 0f;
        
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                sourisx = hit.point.x;
                sourisy = hit.point.y;
                sourisz = hit.point.z;
            }
        }
        Debug.Log(sourisx + " " + sourisy + " " + sourisz);
    }
}
