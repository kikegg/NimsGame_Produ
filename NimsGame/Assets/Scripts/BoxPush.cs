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

    private void Update()
    {

        if (empujarCaja == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            { 
                box.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                box.GetComponent<FixedJoint2D>().connectedBody = rb;
                box.GetComponent<FixedJoint2D>().enabled = true;
            }

        }

        if (Input.GetKeyUp(KeyCode.E))
        {
            box.GetComponent<FixedJoint2D>().enabled = false;
            box.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
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
