using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unite_ennemie : Unite
{
    public void Deplacement(Unite targetUnit){
        if(targetUnit != null && this.Vie>0){

            Vector3 targetPosition = new Vector3(targetUnit.Positionx, targetUnit.Positiony, targetUnit.Positionz);
            Vector3 direction = (targetPosition - new Vector3(this.Positionx, this.Positiony, this.Positionz)).normalized;
 
            float distance = Outil.distanceUnite(this,targetUnit);
            if(distance > 5f){
                Vector3 movement = direction * VitesseDeplacement * Time.deltaTime;
                DeplacerVector(movement);
            }
        }
    }


    
    
}
