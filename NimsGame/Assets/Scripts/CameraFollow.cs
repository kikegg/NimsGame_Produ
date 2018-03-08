using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    TargetJoint2D tj;
    GameObject player;
    GameObject player2;

    // Use this for initialization
    void Start () {
        tj = GetComponent<TargetJoint2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        player2 = GameObject.FindGameObjectWithTag("Player2");
    }
	
	// Update is called once per frame
	void Update () {
        if ((player.GetComponent<PjController>().enabled == true))
        {
            tj.target = (Vector2)player.transform.position;
        } else 
        {
            tj.target = (Vector2)player2.transform.position;
        }
	}
}
