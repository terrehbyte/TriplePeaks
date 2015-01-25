using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class EvilSister : MonoBehaviour 
{
	public GameObject _Brother;			//Our victim!
	public float _Speed = 15F;			//How fast we can chase him down
	public int _ChaseInterval = 3;		//How often we can charge (in seconds)
	public int _Health = 4;				//How many vegetables we can stomache before we die.
	public bool _Invulnerable = true;	//Flag for when 
	public Text _Dialogue;

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
		if(_Brother)
		{
			//Evil sister will charge every x seconds, where x is the integer value set in the inspector.
			if(DateTime.Now >= _lastChaseTime + new TimeSpan(0,0,_ChaseInterval))
			{
				_lastChaseTime = DateTime.Now;
				_positionToCharge = _Brother.transform.position;
				transform.LookAt (_positionToCharge);
			}
			
			//Evil sister is invulnerable to veggies unless her mouth is open!
			//Her mouth is open when she's moving charging.
			if(Vector3.Distance (transform.position, _positionToCharge) <= 1.5F)
			{
				_Invulnerable = true;
			}
			else
			{
				_Invulnerable = false;
			}
			
			//Chhharrggggeee!
			transform.position = Vector3.MoveTowards (transform.position, _positionToCharge, _Speed * Time.deltaTime);
			
			//THE VEGGIES OH GOD I NEED BLOOOOOODDDDDDDDDDD...
			if(_Health <= 0)
			{
				Destroy (gameObject);
			}
		}
	}

	void OnTriggerEnter(Collider col)
	{
		//Stop if we hit our brother
		if(col.gameObject == _Brother)
		{
			_positionToCharge = transform.position;
			_Brother.GetComponent<Player>()._Health--;
			_Dialogue.text = "OMM NOM NOM NOM NOM !";
		}
	}


}
