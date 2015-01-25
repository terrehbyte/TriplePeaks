using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
		
	public float _Speed = 6F;
	public GameObject _VeggiePrefab;
	public GameObject _Sister;



	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		DetectInput ();
	}

	void DetectInput()
	{
		//Shooting

		if(Input.GetMouseButtonDown(0))
		{
			if(_Sister)
			{
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

		transform.Translate (movement * Time.deltaTime);
	}
}
