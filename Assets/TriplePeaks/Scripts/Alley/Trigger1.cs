using UnityEngine;
using System.Collections;

public class Trigger1 : MonoBehaviour {

    public GameObject Player;
    
    // Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.tag == "Player")
        {
            Player.gameObject.GetComponent<WalkingToBody>().ChangeCamera();
            Player.gameObject.GetComponent<WalkingToBody>().WalkedToBody = true;
        }
    }
}
