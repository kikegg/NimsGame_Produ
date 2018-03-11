using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPlayer : MonoBehaviour {

    public FixedJoint2D boxJoint;
    Vector3 positionP1;
    public GameObject p2;

    private void Update()
    {
        positionP1 = new Vector3(0, 0, 0);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        try
        {
            if ((other.gameObject.transform.parent.tag == "pushable") && (boxJoint.enabled == true))
            {
                positionP1 = new Vector3(other.transform.position.x, this.transform.position.y, other.transform.position.z);
                this.transform.position = positionP1;
                this.transform.localScale = p2.transform.localScale;
            }
        }
        catch (System.NullReferenceException)
        {

        }
    }
}
