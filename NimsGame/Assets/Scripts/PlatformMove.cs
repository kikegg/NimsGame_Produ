using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour {

	public GameObject platform;
	public float speed;
	public Transform currentPoint;
	public Transform[] points;
	public int pointSelection;

	// Use this for initialization
	void Start () {
		currentPoint = points [pointSelection];
	}

	void FixedUpdate () {
		if (platform.gameObject == null)
			return;
		
		platform.transform.position = Vector3.MoveTowards (platform.transform.position, currentPoint.position, Time.deltaTime * speed);
		if (platform.transform.position == currentPoint.position) {
			pointSelection += 1;

			if (pointSelection == points.Length) {
				pointSelection = 0;
			}
			currentPoint = points [pointSelection];
			;
		}
	}
}
