using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EntryLevelPlayer : MonoBehaviour 
{
	
	bool _canOpenDoor = false;
	bool _canActiveSwitch = false;
	bool _dead = false;
	bool _colliding = false;
	public float _Speed = 5F;
	private bool _done = false;
	public Text _message;
	
	public GameObject door;
	
	// Use this for initialization
	void Start () 
	{
		_message.text = "";
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(!_done)
		{
			if(!_dead)
			{
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
				
				if(_canOpenDoor && Input.GetMouseButtonUp(0))
				{
					door.transform.position = transform.position;
					door.transform.rotation = new Quaternion(180,0,0, transform.rotation.w);
					_dead = true;
				}
				if(_canActiveSwitch && Input.GetMouseButtonUp (0))
				{
					_done = true;
				}
				
				if(!_colliding)
				{
					_message.text = "That door man.";
				}
			}
		}
	
	
		if(_done )
		{
			_message.text = "Pls transition code.";
			if(Input.GetMouseButtonUp(0))
		   	{
                LevelSystem.instance.LoadNextLevel();
			}
		}

		if(_dead)
		{
			_message.text = "Shouldn't of touched that door man. Retry?";
			renderer.enabled = false;
			if(Input.GetMouseButtonDown (0))
			{
                LifeSystem.instance.Lives--;
				Application.LoadLevel(Application.loadedLevel);
			}
            
		}
		
	}
	
	void OnTriggerStay(Collider c)
	{
		_colliding = true;
		if(c.collider.tag == "Door")
		{
			_message.text = "Open the door?";
			_canOpenDoor = true;
		}
		if(c.collider.tag == "Switch")
		{
			_message.text = "Open the door! From the side!!";
			_canOpenDoor = false;
			_canActiveSwitch = true;
		}
	}
	void OnTriggerExit(Collider c)
	{
		_message.text = "Dat. Door.";
	}
	
}
