//Despina Athanasleri 154427
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public Hammer hammer;
    public int score = 0;
    public AudioClip hitSound;
    public AudioSource AlienSource;
    public AudioClip explosionSound;
    public AudioSource SpaceshipSource;

    // Use this for initialization
    void Start () {
        AlienSource.clip = hitSound;
        SpaceshipSource.clip = explosionSound;
    }

    // Update is called once per frame
 void Update () {
        if (Input.GetMouseButtonDown(0)) //Αν πατηθεί το αριστερό κουμπί του ποντικιοί επιστρέφει true
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); //κρατάμε την θέση του ποντικιού 
            RaycastHit hit; //Αποθηκεύει πληροφορίες από οτι χτυπάμε
                
            if (Physics.Raycast(ray, out hit, 100.0f)) //επιστρέφει true αν χτυπήσουμε κάτι 
              {

                Transform objectHit = hit.transform;
                if (hit.transform.GetComponent<Alien>() != null) //Αν αυτό το αντικείμενο είναι αντικείμενο της κλάσης Alien τότε επιστρέφει true
                {
                    Alien alien = hit.transform.GetComponent<Alien>(); //Κρατάμε το αντικείμενο Alien σε μια μεταβλητή 
                    if (alien.isVisible) //Αν αυτό το αντικείμενο είναι ορατό επιστρέφει true
                    {
                        alien.OnHit(); //Καλούμε την μέθοδο OnHit() της κλάσης Alien
                        
                        AlienSource.Play(); //Ο ήχος που έχουμε θέσει παίζει
                        Vector3 hitVector = new Vector3(alien.transform.position.x -1f,
                                            alien.transform.position.y,
                                            alien.transform.position.z ); //Κρατάμε σε μια μεταβλητή την θέση του αντικειμένου που χτυπήσαμε
                        hammer.Hit(hitVector); //Την δίνουμε στο σφυρί
                        score++; //Αυξάνουμε το σκορ
                    }
                }else if(hit.transform.GetComponent<Spaceship>() != null)
                {
                    Spaceship spaceship = hit.transform.GetComponent<Spaceship>();
                    SpaceshipSource.Play();     
                    spaceship.OnHit(); 
                    Vector3 hitVector = new Vector3(spaceship.transform.position.x - 1f,
                                            spaceship.transform.position.y,
                                            spaceship.transform.position.z); //Κρατάμε σε μια μεταβλητή την θέση του αντικειμένου που χτυπήσαμε
                    hammer.Hit(hitVector); //Την δίνουμε στο σφυρί
                    score = score + 5;
                }
            }
        }
	}

}
