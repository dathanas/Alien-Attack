//Despina Athanasleri 154427
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    public GameObject explosion;
    private float latestDirectionChangeTime;
    private readonly float directionChangeTime = 3f;
    private float characterVelocity = 2f;
    private Vector3 movementDirection;
    private Vector3 movementPerSecond;
    


    void Start()
    {
        latestDirectionChangeTime = 0f;
        calcuateNewMovementVector();
        
    }

    void calcuateNewMovementVector()
    {
        //Δημιουργία προορισμού
        movementDirection = new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f)).normalized;
        movementPerSecond = movementDirection * characterVelocity;
    }

    void Update()
    {
        //Αν τελείωσε ο χρόνος υπολογισμός νέου προορισμού 
        if (Time.time - latestDirectionChangeTime > directionChangeTime)
        {
            latestDirectionChangeTime = Time.time;
            calcuateNewMovementVector();
        }

        //Μετακίνηση διαστημόπλοιου: 
        transform.position = new Vector3(transform.position.x + (movementPerSecond.x * Time.deltaTime),
        transform.position.y + (movementPerSecond.y * Time.deltaTime), transform.position.z + (movementPerSecond.z * Time.deltaTime));

    }

    void DestroyGameObject()
    {
        Instantiate(explosion, transform.position, transform.rotation);//Δημιουργία έκρηξης σε συγκεκριμενο σημειο
        Destroy(gameObject);//Καταστροφή αντικειμένου
    }

    public void OnHit() 
    {
        DestroyGameObject();   
    }
}
