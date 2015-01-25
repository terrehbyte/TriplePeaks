using UnityEngine;
using System.Collections;

public class PlayerCarControl : MonoBehaviour {

	public Transform  playerTransform;
	public float speed;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		//currentPosition.position = playerTransform.position;

		if (Input.GetKey (KeyCode.LeftArrow)) {
			if (playerTransform.position.x <= 4)
						playerTransform.Translate (new Vector3 (speed * Time.deltaTime, 0, 0));
				}

		if (Input.GetKey (KeyCode.RightArrow)) {
			if (playerTransform.position.x >= -4)
				playerTransform.Translate (new Vector3 (-speed * Time.deltaTime, 0, 0));
				}
		//nextPosition.position.x = currentPosition.position.x + moveX;
		//playerTransform.position = nextPosition.position;

	}
}
