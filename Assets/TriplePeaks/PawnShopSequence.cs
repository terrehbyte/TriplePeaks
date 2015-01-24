using UnityEngine;
using System.Collections;

public class PawnShopSequence : MonoBehaviour
{
    public WaypointCharacter Protagonist;
    public DialogueSystem PawnShopDialogue;

    int progress = 0;

	// Use this for initialization
	void Start ()
    {
        // subscribe to waypoint system
        Protagonist.WaypointChanged += HandleWaypointCharacter;
        Protagonist.ShouldMove = true;  // start the first move
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void HandleWaypointCharacter(object sender, WaypointArgs wayArgs)
    {
        if (progress == 0)
        {
            Protagonist.ShouldMove = false;
        }

        ++progress;
    }
}
