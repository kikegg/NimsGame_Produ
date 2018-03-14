using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPush : MonoBehaviour {
    public Rigidbody2D rb;
    public bool empujarCaja = false;
    public GameObject box;
    


    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (empujarCaja == true)
        {
            this.gameObject.GetComponent<Pj2Controller>().facingRight = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                this.gameObject.GetComponent<Animator>().Play("Push");
                box.GetComponent<Rigidbody2D>().mass = 1;
                box.GetComponent<FixedJoint2D>().connectedBody = rb;
                box.GetComponent<FixedJoint2D>().enabled = true;
                box.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            }

        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            this.gameObject.GetComponent<Animator>().Play("Idle");
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<Rigidbody2D>().mass = 1;
            box.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
            empujarCaja = false;
        }

    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "pushable" )
        {
            empujarCaja = true;
            box = coll.gameObject;
        }
        else
        {
            empujarCaja = false;
        }
    }
}
