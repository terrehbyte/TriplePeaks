using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

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
        Player.GetComponent<WalkingToBody>().BombClicked = true;

        LevelSystem.instance.LoadNextLevel();
    }

}
