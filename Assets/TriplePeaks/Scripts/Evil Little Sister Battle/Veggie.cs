using UnityEngine;
using System;
using System.Collections;

public class Veggie : MonoBehaviour
{
	public Vector3 _Direction = new Vector3(0,0,0);
	public Vector3 _Target;
	private float _Speed = 15F;

	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{	
		transform.position = Vector3.MoveTowards (transform.position, _Target, _Speed * Time.deltaTime);
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.gameObject.tag == "Sister" && col.gameObject.GetComponent<EvilSister>()._Invulnerable == false)
		{
			col.gameObject.GetComponent<EvilSister>()._Health --;
			col.gameObject.GetComponent<EvilSister>().LastDialogueDisplay = DateTime.Now;
			col.gameObject.GetComponent<EvilSister>()._Dialogue.text = "Yuck! Augghhh...";
		}
		Destroy (gameObject);
	
	}



}
