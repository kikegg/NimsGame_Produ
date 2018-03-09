using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPlayer : MonoBehaviour {

    public FixedJoint2D boxJoint;
    public GameObject box;

    private void Start()
    {
        boxJoint = GetComponentInParent<FixedJoint2D>();
        box = this.transform.parent.gameObject;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player") && (boxJoint.enabled == true))
        {
            other.gameObject.transform.parent = box.transform;
        }
    }
}
