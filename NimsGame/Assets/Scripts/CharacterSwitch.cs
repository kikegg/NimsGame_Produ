using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour {

    public GameObject ip1;
    public PjController p1;
    public Animator p1Anim;
    public Rigidbody2D p1Rigid;
    public GameObject ip2;
    public Pj2Controller p2;
    public Animator p2Anim;
    public Rigidbody2D p2Rigid;
    public bool onGroundP1;
    public bool onGroundP2;
    public GameObject p1Lives;
    public GameObject p2Lives;

    // Use this for initialization
    void Start () {
        p1.enabled = true;
        ip1.SetActive(true);
        p1Lives.SetActive(true);
        p1Rigid.mass = 1;
        p2.enabled = false;
        ip2.SetActive(false);
        p2Lives.SetActive(false);
        p2Rigid.mass = 100000;
        p2Anim.SetBool("Grounded", true);
        p1Rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
        p2Rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }
	
	// Update is called once per frame
	void Update () {
        onGroundP1 = p1.grounded;
        onGroundP2 = p2.grounded;

        if (Input.GetKeyDown(KeyCode.O))
        {

            if ((p1.enabled== true) && (onGroundP1 == true))
            {   
                p1.enabled = false;
                ip1.SetActive(false);
                p1Lives.SetActive(false);
                p1Anim.SetBool("Moving", false);
                p1Rigid.mass = 100000;
                p1Rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation ;
                //p1Rigid.drag = 100;
                p2.enabled = true;
                ip2.SetActive(true);
                p2Lives.SetActive(true);
                p2Rigid.mass = 1;
                p2Rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
                //p2Rigid.drag = 0;
            }
            else if ((p2.enabled==true) && (onGroundP2==true))
            {
                p1.enabled = true;
                ip1.SetActive(true);
                p1Lives.SetActive(true);
                p1Rigid.mass = 1;
                p1Rigid.constraints = RigidbodyConstraints2D.FreezeRotation;
                //p1Rigid.drag = 0;
                p2.enabled = false;
                ip2.SetActive(false);
                p2Lives.SetActive(false);
                p2Anim.SetBool("Moving", false);
                p2Rigid.mass = 100000;
                p2Rigid.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
                //p2Rigid.drag = 100;
            }
        }
	}
}
