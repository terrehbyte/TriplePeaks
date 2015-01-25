using UnityEngine;
using System.Collections;

public class EverythingMove : MonoBehaviour {

	public Transform envTransform;
	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		envTransform.Translate (new Vector3 (0, 0, speed * Time.deltaTime));
	}
}
