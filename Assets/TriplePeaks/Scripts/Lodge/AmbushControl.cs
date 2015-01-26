using UnityEngine;
using System.Collections;

public class AmbushControl : MonoBehaviour {

	public Transform playerTrans;
	public Transform villTrans;
	
	Transform gunTrans;
	Rigidbody gunRB;

	float progWP1speed;
	float villWP1speed;
	float progDisarmSpeed;

	float actionTimer; 

	bool pWP1reached;
	bool vWP1reached, vRunAwayReached;
	bool pDisarmReached; 
	
	bool disarmKeyPressed;

	Vector3 progWP1;
	Vector3 villWP1, villWP2;
	Vector3 disarmOffset;
	Vector3 gunForcePos;

	// Use this for initialization
	void Start () {
	
		progWP1speed = 10;
		villWP1speed = 35;
		progDisarmSpeed = 40;

		actionTimer = 0f;

		pWP1reached = false;
		vWP1reached = false;
		pDisarmReached = false;
		vRunAwayReached = false;
		
		disarmKeyPressed = false;

		progWP1 = GameObject.Find ("progWP1").transform.position;
		villWP1 = GameObject.Find ("villWP1").transform.position;
		villWP2 = GameObject.Find ("villWP2").transform.position;
		
		gunRB = GameObject.Find ("gun").rigidbody;
		gunRB.isKinematic = true;
		gunTrans = GameObject.Find ("gun").transform;

		disarmOffset = new Vector3 (0, 0, -6f);
		Vector3 forcePosOffset = new Vector3(0,0,2f);
		
		gunForcePos = gunTrans.localPosition + forcePosOffset;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			disarmKeyPressed = true;
		}
	

		if (pDisarmReached && !vRunAwayReached)
		{
			vRunAway();
		}

		if (vWP1reached && !pDisarmReached)
		{
			if (disarmKeyPressed)
			{
				pDisarm ();
			}
		}
		
		else if (pWP1reached && !vWP1reached)
		{
			vWayPoint1 ();
		}

		else if (!pWP1reached)
		{
			pWayPoint1 ();
		}

		
//		if (Input.GetKeyDown (KeyCode.DownArrow))
//						pDuck ();

		Debug.Log (vWP1reached);


	}

	void pWayPoint1()
	{
		float step = progWP1speed * Time.deltaTime;
		if (!WithinRange (playerTrans.position, progWP1))
		{
				playerTrans.position = Vector3.MoveTowards (playerTrans.position, progWP1, step);		
		}
		else
		{
			pWP1reached = true;
		}
	}

	void vWayPoint1()
	{
		float step = villWP1speed * Time.deltaTime;
		if (!WithinRange (villTrans.position, villWP1))
		{
			villTrans.position = Vector3.MoveTowards (villTrans.position, villWP1, step);
		}
		else
		{
			playerTrans.Rotate (0,80,0);
			vWP1reached = true;
		}
	}

	void pDisarm()
	{
		float step = progDisarmSpeed * Time.deltaTime;
		
		if (!WithinRange (playerTrans.position, villTrans.position + disarmOffset ))
		{
			playerTrans.position = Vector3.MoveTowards (playerTrans.position, villTrans.position + disarmOffset, step);
		}
		else
		{
			gunRB.isKinematic = false;
			gunTrans.parent = null;
			gunRB.AddForceAtPosition(new Vector3(-0.3f,1f,0) * 18f, gunForcePos, ForceMode.Impulse);
			pDisarmReached = true;
		}
	}

	void vRunAway()
	{
		
		float step = villWP1speed * Time.deltaTime;
		if (!WithinRange (villTrans.position, villWP2))
		{
			villTrans.position = Vector3.MoveTowards (villTrans.position, villWP2, step);
		}
		else
		{
			vRunAwayReached = true;
		}
	}

	bool WithinRange(Vector3 v1, Vector3 v2)
	{
		if (Vector3.Distance (v1, v2) <= .01f)
		{
			return true;
		}

		return false;
	}
		
}
