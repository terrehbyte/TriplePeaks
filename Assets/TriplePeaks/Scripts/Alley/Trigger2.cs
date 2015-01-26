using UnityEngine;
using System.Collections;

public class Trigger2 : MonoBehaviour {

    public GameObject Clothes;
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
        if (c.gameObject.tag == "Clothes")
        {
            Player.gameObject.GetComponent<WalkingToBody>().ChangeCamera2();
            Player.gameObject.GetComponent<WalkingToBody>().RemovedClothes = true;
        }
    }
}
