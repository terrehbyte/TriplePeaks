using UnityEngine;
using System.Collections;
using System;

public class Player : MonoBehaviour 
{
		
	public float _Speed = 6F;
	public GameObject _Cutscene;
	public GameObject _VeggiePrefab;
	public GameObject _Sister;
	private DateTime _whenLastShot;
	private TimeSpan _shotDelay;
	public int _Health = 3;

	public bool Invulnerable {get;set;}
	public DateTime WhenToLoseInvuln;

	// Use this for initialization
	void Start () 
	{
		Invulnerable = false;
		WhenToLoseInvuln = new DateTime();

		_whenLastShot = DateTime.Now;
		_shotDelay = new TimeSpan(0,0,1);
	}
	
	// Update is called once per frame
	void Update () 
	{
		DetectInput ();

		if(_Health <= 0)
		{
			//Destroy (gameObject);
		}
	}

	void DetectInput()
	{
		if(_Cutscene.GetComponent<Cutscene>().Finished == true)
		{
			//Shooting
			if(Input.GetMouseButtonUp(0) && DateTime.Now >= _whenLastShot + _shotDelay)
			{
				if(_Sister)
				{
					_whenLastShot = DateTime.Now;
					
					Vector3 directionToSister = Vector3.Normalize(_Sister.transform.position - transform.position);
					Vector3 offset = directionToSister * 1.5F;
					
					GameObject newVeggie = Instantiate (_VeggiePrefab, transform.position + offset, transform.rotation) as GameObject;
					newVeggie.GetComponent<Veggie>()._Target = _Sister.transform.position;
				}
			}
			
			//Movement
			Vector3 movement = new Vector3(0F, 0F, 0F);
			
			if(Input.GetKey (KeyCode.UpArrow))
			{
				movement.z = _Speed;
			}
			if(Input.GetKey (KeyCode.DownArrow))
			{
				movement.z = _Speed * -1;
			}
			if(Input.GetKey (KeyCode.LeftArrow))
			{	
				movement.x = _Speed * -1;
			}
			if(Input.GetKey (KeyCode.RightArrow))
			{
				movement.x = _Speed;
			}
			
			//transform.Translate (movement * Time.deltaTime);
			transform.position = Vector3.MoveTowards (transform.position, transform.position + movement, Time.deltaTime * _Speed);
			transform.LookAt ( transform.position + movement * Time.deltaTime);

			//Invulnerability
			if(Invulnerable == true)
			{
				gameObject.renderer.enabled = !gameObject.renderer.enabled; //flicker
			}
			if(DateTime.Now >= WhenToLoseInvuln)
			{
				Invulnerable = false;
			}
		}

	}
}
