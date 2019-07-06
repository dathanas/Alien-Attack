//Despina Athanasleri 154427
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour {

    public float visibleHeight = 0.2f;
    public float hiddenHeight = -0.9f;
    public float speed = 2f;
    public float disappearDuration = 1f;
    private float disappearTimer = 0f;
    private Vector3 targetPosition;
    public bool isVisible;


	// Use this for initialization
	void Awake () { 
        targetPosition = new Vector3(
            transform.localPosition.x,
            hiddenHeight,
            transform.localPosition.z); //Η θέση του εξωγήινου όταν ξεκινάει το παιχνίδι
        isVisible = false; //Θέτω στην μεταβλητή isVisible την τιμή false
        transform.localPosition = targetPosition; //Αναγκάζει το αντικείμενο να αποκτήσει την θέση που δημιουργήσαμε απο πάνω
	}
	
	// Update is called once per frame
	void Update () { 
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, Time.deltaTime * speed); 
        disappearTimer -= Time.deltaTime; //Countdown
        if(disappearTimer < 0f) //Όταν ο χρόνος γίνει μικρότερος απο μηδέν τότε επιστρέφει true
        {
            Hide(); //Καλείται η μέθοδος Hide
        }
	}

    public void Rise()
    {
        targetPosition = new Vector3(
           transform.localPosition.x,
           visibleHeight,
           transform.localPosition.z); //Η θέση του εξωγήινου όταν εμφανίζεται 
        isVisible = true; //Θέτω στην μεταβλητή isVisible την τιμή true
        disappearTimer = disappearDuration; //Ο χρόνος που θα φαίνεται ο εξωγήινος 
    }

    public void Hide()
    {
        targetPosition = new Vector3(
           transform.localPosition.x,
           hiddenHeight,
           transform.localPosition.z); //Η θέση του εξωγήινου όταν κρυβεται
        isVisible = false; //Θέτω στην μεταβλητή isVisible την τιμή false
    }
    public void OnHit() //Όταν καλείται η μέθοδος  OnHit() καλείται μετά η μέθοδος Hide()
    {
        Hide();
    }
}
