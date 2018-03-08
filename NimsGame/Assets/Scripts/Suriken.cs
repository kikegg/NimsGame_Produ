using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suriken : MonoBehaviour {
    public float surikenSpeed;
    private Rigidbody2D theRB;

    //public GameObject surikenEffect;

    // Use this for initialization
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        theRB.velocity = new Vector2(surikenSpeed * transform.localScale.x, 0);
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
            Destroy(other.gameObject);
        
        Instantiate(surikenEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }*/
}

