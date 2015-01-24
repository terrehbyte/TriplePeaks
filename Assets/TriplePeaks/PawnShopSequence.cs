using UnityEngine;
using System.Collections;

public class PawnShopSequence : MonoBehaviour
{
    public WaypointCharacter Protagonist;
    public DialogueSystem PawnShopGreetingDialogue;
    public DialogueSystem PawnShopItemDialogue;

    int progress = 0;

	// Use this for initialization
	void Start ()
    {
        // subscribe to waypoint system
        Protagonist.WaypointChanged += HandleWaypointCharacter;
        Protagonist.ShouldMove = true;  // start the first move

        // subscribe to 
        PawnShopGreetingDialogue.DialogueChosen += DebugDialogue;
        PawnShopGreetingDialogue.DialogueChosen += HandleGreetingChoice;

        PawnShopGreetingDialogue.DiagBox.DialogueInteracted += HandleGreetingDialogue;

        PawnShopItemDialogue.DialogueChosen += DebugDialogue;
        PawnShopItemDialogue.DialogueChosen += HandleItemChoice;

        PawnShopItemDialogue.DiagBox.DialogueInteracted += HandleItemDialogue;
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
            PawnShopGreetingDialogue.gameObject.SetActive(true);
        }

        ++progress;
    }

    void HandleGreetingChoice(object sender, DialogueArgs dialog)
    {
        string choice = dialog.dialgogueSelected;

        PawnShopGreetingDialogue.ChoicesCanvas.gameObject.SetActive(false);
        PawnShopGreetingDialogue.DiagBox.gameObject.SetActive(true);

        switch (choice)
        {
            case "How are you?":
                {
                    PawnShopGreetingDialogue.DiagBox.AssignDialogue("fuck you 1");
                    break;
                }
            case "How is the weather?":
                {
                    PawnShopGreetingDialogue.DiagBox.AssignDialogue("fuck you 2");
                    break;
                }
            case "Comfort myself.":
                {
                    PawnShopGreetingDialogue.DiagBox.AssignDialogue("*comforts*");
                    break;
                }
            default:
                {
                    PawnShopGreetingDialogue.DiagBox.AssignDialogue("ERR NO CHOICE");
                    break;
                }
        }
    }
    void HandleGreetingDialogue(object sender, DialogueBoxArgs diaArgs)
    {
        ++progress;
        PawnShopItemDialogue.gameObject.SetActive(true);
    }
    
    void HandleItemChoice(object sender, DialogueArgs dialog)
    {
        string choice = dialog.dialgogueSelected;

        PawnShopItemDialogue.ChoicesCanvas.gameObject.SetActive(false);
        PawnShopItemDialogue.DiagBox.gameObject.SetActive(true);

        switch (choice)
        {
            case "How much is it worth?":
                {
                    PawnShopItemDialogue.DiagBox.AssignDialogue("TODO");
                    break;
                }
            case "Who would buy this?":
                {
                    PawnShopItemDialogue.DiagBox.AssignDialogue("TODO");
                    break;
                }
            case "Where would someone get this?":
                {
                    PawnShopItemDialogue.DiagBox.AssignDialogue("TODO");
                    break;
                }
            default:
                {
                    PawnShopItemDialogue.DiagBox.AssignDialogue("YOU FUCKED. *BROKEN CHOICE*");
                    break;
                }
        }
    }
    void HandleItemDialogue(object sender, DialogueBoxArgs dialog)
    {
        ++progress;
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
