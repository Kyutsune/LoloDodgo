using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unite : MonoBehaviour
{
    private float positionx;
    private float positiony;
    private float positionz;
    private int vie;
    private int attaque;
    private int portee;
    private int vitesse_deplacement;
    private float vitesse_attaque;
    private float vitesse_projectiles;

    private GameObject corps_unite;
    private Gestion_prefab gestion_prefab_unite;

    private Controleur_Animation animator_controller;
    private Animator animator_unite_a_controller;

    public GameObject bulletPrefab;



    private bool iswalking;
    private bool isshooting;



    ///Ici on a les valeurs qui vont nous servir a faire marcher l'animation de tir de l'unité
    //Celle ci correspond au temps nécessaire à la transition entre la marche et le tir
    public float temps_lever_arme=1.28f; 
    //Ici le temps qui correspond au tir,puis au temps pour se remettre en marche
    public float shootingDuration = 1.72f;
    public bool en_position_pour_tirer=false;


    public float Positionx
    {
        get { return positionx; }
        set { positionx = value; }
    }
    public float Positiony
    {
        get { return positiony; }
        set { positiony = value; }
    }

    public float Positionz
    {
        get { return positionz; }
        set { positionz = value; }
    }

    public Vector3 GetPosition() { return new Vector3(positionx, positiony+1, positionz); }

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

    public bool IsWalking
    {
        get { return iswalking; }
        set { iswalking = value; }
    }

    public bool IsShooting
    {
        get { return isshooting; }
        set { isshooting = value; }
    }

    public void Initialisation(float positionx, float positiony, float positionz, int vie, int attaque, float vitesse_projectiles,int VitesseDeplacement)
    {
        this.positionx = positionx;
        this.positiony = positiony;
        this.positionz = positionz;
        this.vie = vie;
        this.attaque = attaque;
        this.vitesse_projectiles = vitesse_projectiles;
        this.iswalking = false;
        this.isshooting = false;
        this.en_position_pour_tirer=false;
        this.vitesse_deplacement=VitesseDeplacement;
        gestion_prefab_unite = new Gestion_prefab();
        corps_unite = gestion_prefab_unite.CreerPrefab(Positionx,Positiony,Positionz);

        animator_controller = gameObject.AddComponent<Controleur_Animation>();
        animator_unite_a_controller=corps_unite.GetComponent<Animator>();
        animator_controller.Start_animator_controler(animator_unite_a_controller);

    }


    public void Deplacer(float x, float y, float z)
    {
        this.positionx = x;
        this.positiony = y;
        this.positionz = z;
    }
    public void DeplacerVector(Vector3 newPosition)
    {
        this.positionx = newPosition.x;
        this.positiony = newPosition.y;
        this.positionz = newPosition.z;
    }

    public void Attaquer(Unite unite)
    {
        unite.vie -= this.attaque;
    }



///Ici a titre éducatif,je rajoute l'explication des mots clés protected et virtual (donnés par chatgpt)
/* Explication
En utilisant le modificateur protected, vous permettez aux classes dérivées telles que Unite_humaine d'accéder et de redéfinir 
la méthode Update() si nécessaire. Notez également l'utilisation du mot-clé virtual, ce qui signifie que cette méthode peut être 
redéfinie dans les classes dérivées si besoin.
*/
//voir l'utilisation de ce Update dans la classe Unite_humaine par exemple,dans sa propre Update()
    protected virtual void Update()
    {
        if (this.vie <= 0)
        {
            Destroy(this.gameObject);
            gestion_prefab_unite.DetruirePrefab(corps_unite);
        }

        if(UnityEngine.Input.GetKeyDown(KeyCode.T))
        {
            if(IsWalking==true)
            {
                StartShooting(temps_lever_arme,shootingDuration);
                StopWalking(temps_lever_arme+shootingDuration);
            }
        }

        gestion_prefab_unite.DeplacerPrefab_a_partir_unite(corps_unite, this);
        animator_controller.animation(this, animator_unite_a_controller);

        
        Attaquer(this);
    }


    // Fonction pour démarrer le tir pendant une durée spécifiée
    void StartShooting(float temp_a_lever_arme,float duration)
    {
        StartCoroutine(Shoot_after_temps_lever_arme(temp_a_lever_arme));
        StartCoroutine(StopShootingAfterDuration(duration));
    }

    void StopWalking(float duration)
    {
        StartCoroutine(StopWalkingForDuration(duration));
    }


    IEnumerator Shoot_after_temps_lever_arme(float duration)
    {
        en_position_pour_tirer=true;
        yield return new WaitForSeconds(duration);
        IsShooting = true;
        IsWalking = false;
        en_position_pour_tirer=false;

        // Obtenez la rotation de votre unité
        Quaternion unitRotation = GetRotation();
        Debug.Log("unitRotation : " + unitRotation);

        // Créez le projectile avec la rotation de l'unité
        var bullet = Instantiate(Resources.Load<GameObject>("Prefab/prefab_Projectile_final"), GetPosition(), unitRotation);
        bullet.layer = LayerMask.NameToLayer("Projectile_roro");

        // Utilisez la rotation pour calculer la direction de déplacement
        Vector3 moveDirection = unitRotation * Vector3.forward;


        // Affectez une rotation particulière au projectile
        bullet.transform.rotation = Quaternion.Euler(270,unitRotation.eulerAngles.y, 0);

        // Affectez cette direction à la vélocité du Rigidbody du projectile
        bullet.GetComponent<Rigidbody>().velocity = moveDirection * vitesse_projectiles;
    }

    // Coroutine pour arrêter le tir après une durée spécifiée
    IEnumerator StopShootingAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        IsShooting = false;
    }

    IEnumerator StopWalkingForDuration(float duration)
    {
        IsWalking = false;

        yield return new WaitForSeconds(duration);
        IsWalking = true;
    }   

    public Quaternion GetRotation()
    {
        return transform.rotation;
    }
}
