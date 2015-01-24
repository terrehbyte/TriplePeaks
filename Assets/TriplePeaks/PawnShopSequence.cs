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

        // subscribe to 
        PawnShopDialogue.DialogueChosen += HandleDialogue;
        PawnShopDialogue.DialogueChosen += DebugDialogue;
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
            PawnShopDialogue.gameObject.SetActive(true);
        }

        ++progress;
    }

    void HandleDialogue(object sender, DialogueArgs diaArgs)
    {
        
    }

    void DebugDialogue(object sender, DialogueArgs diaArgs)
    {
        Debug.Log(diaArgs.dialgogueSelected);
    }

    void transition(int newProgress)
    {
        switch (newProgress)
        {
            case 0:
                {
                    break;
                }
            case 1:
                {
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
}
