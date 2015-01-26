using UnityEngine;
using System.Collections;

public class Limbs : MonoBehaviour {

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
        if (this.tag == "Limb1")
        {
            Player.GetComponent<WalkingToBody>().Limb1Clicked = true;
        }

        if (this.tag == "Limb2")
        {
            Player.GetComponent<WalkingToBody>().Limb2Clicked = true;
        }

        if (this.tag == "Limb3")
        {
            Player.GetComponent<WalkingToBody>().Limb3Clicked = true;
        }

        if (this.tag == "Limb4")
        {
            Player.GetComponent<WalkingToBody>().Limb4Clicked = true;
        }
    }
}
