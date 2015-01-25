using UnityEngine;
using System.Collections;
using System;

public class EvilSister : MonoBehaviour 
{
	public GameObject _Brother;
	public float _Speed = 15F;
	public int _ChaseInterval = 3;
	public int _Health = 4;
	public bool _Invulnerable = true;

	private DateTime _lastChaseTime = DateTime.Now;
	private Vector3 _positionToCharge = new Vector3(0,0,0);


	// Use this for initialization
	void Start () 
	{
		_positionToCharge = _Brother.transform.position;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(DateTime.Now >= _lastChaseTime + new TimeSpan(0,0,_ChaseInterval))
		{
			_lastChaseTime = DateTime.Now;
			_positionToCharge = _Brother.transform.position;
		}

		//If she ain't moving her mouth's closed
		if(Vector3.Distance (transform.position, _positionToCharge) <= 1.5F)
		{
			_Invulnerable = true;
		}
		//Otherwise she's moving and we can throw veggies in her mouth.
		else
		{
			_Invulnerable = false;
		}

		transform.position = Vector3.MoveTowards (transform.position, _positionToCharge, _Speed * Time.deltaTime);

		if(_Health <= 0)
		{
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision col)
	{
		//Stop if we hit our brother
		if(col.gameObject == _Brother)
		{
			_positionToCharge = transform.position;
		}
	}
}
