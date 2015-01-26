using UnityEngine;
using System.Collections;

public class Note : MonoBehaviour {

    public GameObject Player;
    
    // Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {

	}

    void OnMouseDown()
    {
        Player.GetComponent<WalkingToBody>().NoteRead = true;
    }
}
