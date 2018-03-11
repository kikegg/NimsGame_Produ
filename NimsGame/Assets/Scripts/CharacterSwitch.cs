using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour {

    public PjController p1;
    public Animator p1Anim;
    public Rigidbody2D p1Rigid;
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
        p1Lives.SetActive(true);
        p1Rigid.mass = 1;
        p2.enabled = false;
        p2Lives.SetActive(false);
        p2Rigid.mass = 100000;
        p2Anim.SetBool("Grounded", true);
    }
	
	// Update is called once per frame
	void Update () {
        onGroundP1 = p1.grounded;
        onGroundP2 = p2.grounded;
        if (Input.GetKeyDown(KeyCode.O))
        {
            if((p1.enabled== true) && (onGroundP1 == true))
            {
                p1.enabled = false;
                p1Lives.SetActive(false);
                p1Anim.SetBool("Moving", false);
                p1Rigid.mass = 100000;
                p2.enabled = true;
                p2Lives.SetActive(true);
                p2Rigid.mass = 1;
            }
            else if ((p2.enabled==true) && (onGroundP2==true))
            {
                p1.enabled = true;
                p1Lives.SetActive(true);
                p1Rigid.mass = 1;
                p2.enabled = false;
                p2Lives.SetActive(false);
                p2Anim.SetBool("Moving", false);
                p2Rigid.mass = 100000;
            }
        }
	}
}
