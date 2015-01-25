using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

    public GameObject Player;
    
    // Use this for initialization
	void Start () 
    {
        renderer.material.color = Color.black;
	}
	
	// Update is called once per frame
	void Update () 
    {
	
	}

    void OnMouseDown()
    {
        renderer.material.color = Color.green;
        Player.GetComponent<WalkingToBody>().BombClicked = true;

        LevelSystem.instance.LoadNextLevel();
    }

}
