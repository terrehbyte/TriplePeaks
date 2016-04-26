using UnityEngine;
using System.Collections;

public class RotateClamp : MonoBehaviour {
	
	Quaternion originalRotation;
	public float rotationLimit = 15;
	
	// Use this for initialization
	void Start () {
		originalRotation = GetComponent<Rigidbody>().rotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		GetComponent<Rigidbody>().AddRelativeTorque( Input.GetAxis("Vertical") * Vector3.right * 10 );
		GetComponent<Rigidbody>().AddRelativeTorque( Input.GetAxis("Horizontal") * Vector3.up * 10 );
		
		if (Vector3.Angle(GetComponent<Rigidbody>().rotation * Vector3.up , Vector3.up) > rotationLimit)
		{
			Vector3 flatForwardVector = new Vector3( transform.forward.x, 0, transform.forward.z );
			Quaternion flatRotation = Quaternion.LookRotation( flatForwardVector );
			GetComponent<Rigidbody>().rotation = Quaternion.RotateTowards(flatRotation, GetComponent<Rigidbody>().rotation, rotationLimit);
		}
		
	}
}

