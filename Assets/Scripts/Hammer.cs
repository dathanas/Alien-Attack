//Despina Athanasleri 154427
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hammer : MonoBehaviour {
    public Transform target;
    public float smoothTime = 0.3F;
    private Vector3 velocity = Vector3.zero;
    void Update ()
    {
        Vector3 temp = Input.mousePosition; //Κρατάω την θέση που έχει το ποντίκι
        temp.z = 2f; //Θέτω την τιμή της απόστασης που θέλω να φαίνεται ότι έχει το σφυρί απο την κάμερα
        this.transform.position = Camera.main.ScreenToWorldPoint(temp); //Θέτω αυτή την απόσταση
    }

    public void Hit(Vector3 targetPosition)
    {
        
        targetPosition = target.TransformPoint(new Vector3(0, 15, -10)); // Ορίζει το target position

        
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime); // Μεταφερει το σφυρί απαλά προς τον στόχο
    }
}




