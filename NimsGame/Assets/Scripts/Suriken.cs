using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suriken : MonoBehaviour {
    public float surikenSpeed;
    private Rigidbody2D theRB;
    public AudioSource surikenSound;

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

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy") { 
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (!(other.gameObject.tag == "Player"))
        {
            Destroy(gameObject);
        }
        surikenSound.Play();
    }
}

