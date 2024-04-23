using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCamera : MonoBehaviour
{
    public Unite unite_a_suivre;

    public float decalage_x;
    public float decalage_y;  
    public float decalage_z; 
    
    public float movementSpeed = 5f;
    public float rotationSpeed = 3f;

    void Start()
    {
        transform.position = new Vector3(6f, 6f, -4f);
        transform.rotation = Quaternion.Euler(23f, -33f, 0f);

        decalage_x = 9;
        decalage_y = 5;
        decalage_z = 2;

        unite_a_suivre = FindObjectOfType<Unite_humaine>();
        if(unite_a_suivre == null)
            Debug.LogError("L'unité du joueur n'a pas été trouvée.");

        placer_camera_au_dessus_unite(unite_a_suivre);
    }


    void Update()
    {
        placer_camera_au_dessus_unite(unite_a_suivre);

        // Détection du mouvement de la molette de la souris pour rapprocher ou éloigner la caméra
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        // Ajustement des valeurs de décalage en fonction du mouvement de la molette de la souris
        decalage_x -= scroll;
        decalage_y -= scroll;
        decalage_z -= scroll;

        // Clamping pour éviter des valeurs négatives
        decalage_x = Mathf.Max(0f, decalage_x);
        decalage_y = Mathf.Max(0f, decalage_y);
        decalage_z = Mathf.Max(0f, decalage_z);

        /*On garde ce bout de code ne sait-on jamais
        // Déplacement de la caméra basé sur les entrées du joueur
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(movement);

        // Limite la position verticale pour empêcher la caméra d'aller en dessous du sol
        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, groundHeight, float.MaxValue), transform.position.z);


        // Rotation de la caméra avec le clic droit de la souris
        if (Input.GetMouseButton(1)) // 1 représente le bouton droit de la souris
        {
            float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

            // Rotation horizontale (gauche/droite)
            transform.Rotate(Vector3.up * mouseX);

            // Rotation verticale (haut/bas), avec limite verticale
            rotationX -= mouseY;
            rotationX = Mathf.Clamp(rotationX, -verticalLookLimit, verticalLookLimit);

            transform.localRotation = Quaternion.Euler(rotationX, transform.localRotation.eulerAngles.y, 0f);
        }

        // Montée de la caméra lorsque la touche espace est enfoncée
        if (Input.GetKey(KeyCode.Space))
        {
            float verticalMovement = movementSpeed * Time.deltaTime;
            transform.Translate(Vector3.up * verticalMovement);
        }

        // Descente de la caméra lorsque la touche Shift est enfoncée
        if (Input.GetKey(KeyCode.LeftShift))
        {
            float verticalMovement = -movementSpeed * Time.deltaTime;
            transform.Translate(Vector3.up * verticalMovement);
        }
        */
    }


    void placer_camera_au_dessus_unite(Unite unite_a_suivre)
    {
        Vector3 newPosition = unite_a_suivre.transform.position ;


        newPosition.x+=decalage_x;
        newPosition.y+=decalage_y;
        newPosition.z+=decalage_z;


        // Appliquer la position de la caméra
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, -100f, transform.rotation.eulerAngles.z);
    }

}