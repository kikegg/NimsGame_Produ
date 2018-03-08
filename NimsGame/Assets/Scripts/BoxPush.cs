using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPush : MonoBehaviour {
    Rigidbody2D rb;
    bool empujarCaja = false;

    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    private void Update()
    {

        if (empujarCaja == true)
        {
            if (Input.GetKey(KeyCode.E))
            { 
            }
        }

    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "pushable" && Input.GetKey(KeyCode.E))
        {       
            coll.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            coll.gameObject.GetComponent<FixedJoint2D>().connectedBody = rb;
            coll.gameObject.GetComponent<FixedJoint2D>().enabled = true;

          /*  if (Input.GetKeyDown(KeyCode.Q))
            {
                coll.gameObject.GetComponent<FixedJoint2D>().enabled = false;
                coll.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            }*/

        }
      

    }



}
