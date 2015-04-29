using UnityEngine;
using System.Collections;

public class Raycaster : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 fwd = transform.TransformDirection(Vector3.forward);
		Debug.DrawRay(transform.position, fwd*10, Color.green);
		if (Physics.Raycast(transform.position, fwd, 10))
			print("There is something in front of the object!");
	}
}
