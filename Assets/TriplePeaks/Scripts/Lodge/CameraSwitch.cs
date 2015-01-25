using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

	public Camera thisCamera, nextCamera;
	//public Collider endTrigger;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		thisCamera.enabled = false;
		nextCamera.enabled = true;
		Debug.Log ("Triggered!");
	}

}
