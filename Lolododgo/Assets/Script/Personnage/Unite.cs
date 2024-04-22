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

    public void Initialisation(int positionx, int positiony, int positionz, int vie, int attaque,float vitesse_projectiles)
    {
        this.positionx = positionx;
        this.positiony = positiony;
        this.positionz = positionz;
        this.vie = vie;
        this.attaque = attaque;
        this.vitesse_projectiles = vitesse_projectiles;
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
        
        if(UnityEngine.Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Tir");
            //Ici on récupère le point visé par la caméra 
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            Vector3 targetDirection = ray.direction;
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);


            var bullet = Instantiate(Resources.Load<GameObject>("Prefab/prefab_Projectile"), GetPosition(), targetRotation);

            // Récupérez la rotation du projectile
            Quaternion bulletRotation = bullet.transform.rotation;
            // Utilisez la rotation pour calculer la direction de déplacement
            Vector3 moveDirection = bulletRotation * Vector3.forward;
            // Affectez cette direction à la vélocité du Rigidbody
            bullet.GetComponent<Rigidbody>().velocity = moveDirection * vitesse_projectiles;
            Debug.Log(bullet.GetComponent<Rigidbody>().velocity);
        }
    }

    

}
