using UnityEngine;
using System.Collections;

public class PlayerStairControl : MonoBehaviour {

	public Transform playerTrans;
	public Rigidbody playerRB;
	public Collider playerColl;
	public float jumpForce, rightForce;

//	enum DIRECTION
//	{
//		NEUTRAL,
//		UP,
//		RIGHT,
//		DOWN,
//	};

//	DIRECTION dirTrig;

	// bool movingUp, movingRight, movingDown, neutral;

	int jumpCount, rightCount;

	Vector3 up = new Vector3(0,1,0);
	Vector3 right = new Vector3(0,0,-1);
	Vector3 down = new Vector3(0,-1,0);

	Vector3 forcePositionU, forcePositionR, forcePositionD;
	Vector3 forcePosOffset = new Vector3(0,-0.01f,0);


	// Use this for initialization
	void Start () {
//		movingUp = false;
//		movingRight = false;
//		movingDown = false;

		jumpCount = 0;
		rightCount = 0;
	}
	
	// Update is called once per frame
	void Update () {

		forcePositionU = playerTrans.localPosition - forcePosOffset;
		forcePositionR = playerTrans.localPosition + forcePosOffset;
		forcePositionD = playerTrans.localPosition + forcePosOffset;

		if (Input.GetKeyDown (KeyCode.UpArrow) && jumpCount < 1) {
			//playerRB.AddForceAtPosition(up * jumpForce, forcePositionU, ForceMode.Impulse);
			playerRB.AddForce(up * jumpForce, ForceMode.Impulse);
			jumpCount += 1;
		}
		if (Input.GetKeyDown (KeyCode.RightArrow) && rightCount < 1) 
			playerRB.AddForceAtPosition(right * rightForce, forcePositionR, ForceMode.Impulse);
		if (Input.GetKeyDown (KeyCode.DownArrow) ) {
			playerRB.AddForceAtPosition(down * jumpForce, forcePositionD, ForceMode.Impulse);
		} 

	}

	void OnCollisionEnter()
	{
		jumpCount = 0;
		rightCount = 0;
	}
}
