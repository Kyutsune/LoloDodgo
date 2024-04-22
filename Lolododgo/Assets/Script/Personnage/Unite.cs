using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unite : MonoBehaviour
{
    private int positionx;
    private int positiony;
    private int positionz;
    private int vie;
    private int attaque;
    private int portee;
    private int vitesse_deplacement;
    private float vitesse_attaque;
    private float vitesse_projectiles;
    public GameObject bulletPrefab;


    public int Positionx
    {
        get { return positionx; }
        set { positionx = value; }
    }
    public int Positiony
    {
        get { return positiony; }
        set { positiony = value; }
    }

    public int Positionz
    {
        get { return positionz; }
        set { positionz = value; }
    }

    public Vector3 GetPosition() { return new Vector3(positionx, positiony, positionz); }

    public Quaternion GetUniteRotation()
    {
        return transform.rotation;
    }

    public int Vie
    {
        get { return vie; }
        set { vie = value; }
    }

    public int Attaque
    {
        get { return attaque; }
        set { attaque = value; }
    }
    public int Portee
    {
        get { return portee; }
        set { portee = value; }
    }

    public int VitesseDeplacement
    {
        get { return vitesse_deplacement; }
        set { vitesse_deplacement = value; }
    }

    public float VitesseAttaque
    {
        get { return vitesse_attaque; }
        set { vitesse_attaque = value; }
    }

    public float VitesseProjectiles
    {
        get { return vitesse_projectiles; }
        set { vitesse_projectiles = value; }
    }

    public Unite(int positionx, int positiony, int positionz, int vie, int attaque)
    {
        this.positionx = positionx;
        this.positiony = positiony;
        this.positionz = positionz;
        this.vie = vie;
        this.attaque = attaque;
    }


    public void Deplacer(int x, int y, int z)
    {
        this.positionx = x;
        this.positiony = y;
        this.positionz = z;
    }

    public void Attaquer(Unite unite)
    {
        unite.vie -= this.attaque;
    }




    public void GestionEvenement()
    {
        if (this.vie <= 0)
        {
            Destroy(this.gameObject);
        }
        
        if(UnityEngine.Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Tir");
            var bullet = Instantiate(bulletPrefab, GetPosition(), GetUniteRotation());
            bullet.GetComponent<Rigidbody>().velocity = transform.forward * vitesse_projectiles;
        }
    }

    

}
