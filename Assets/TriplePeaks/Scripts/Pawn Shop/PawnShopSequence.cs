using UnityEngine;
using System.Collections;

public class PawnShopSequence : MonoBehaviour
{
    public WaypointCharacter Protagonist;
    public DialogueSystem PawnShopGreetingDialogue;
    public DialogueSystem PawnShopItemDialogue;

    int progress = 0;

    public Transform ItemSpawnpoint;

    public GameObject RolexPrefab;
    public GameObject SatanicBiblePrefab;
    public GameObject RedHerringPrefab;
    
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

#if UNITY_EDITOR
        InventoryItem evidence = new InventoryItem();
        evidence.Name = "Red Herring";

        ItemSystem inv = ItemSystem.instance;
        inv.AddItem("evidence", evidence);
#endif
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
                    PawnShopGreetingDialogue.DiagBox.AssignDialogue("I'm having an eggcellent day!");
                    break;
                }
            case "How is the weather?":
                {
                    PawnShopGreetingDialogue.DiagBox.AssignDialogue("Cloudy, with a chance of spoilage.");
                    break;
                }
            case "What's up?":
                {
                    PawnShopGreetingDialogue.DiagBox.AssignDialogue("The ceiling!");
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

        ItemSystem itSys = ItemSystem.instance;
        InventoryItem item = itSys.GetItem("evidence");

        switch (item.Name)
        {
            case "Rolex":
                {
                    Instantiate(RolexPrefab, ItemSpawnpoint.position, Quaternion.identity);
                    break;
                }
            case "Satanic Bible":
                {
                    Instantiate(SatanicBiblePrefab, ItemSpawnpoint.position, Quaternion.identity);

                    break;
                }
            case "Red Herring":
                {
                    Instantiate(RedHerringPrefab, ItemSpawnpoint.position, Quaternion.EulerAngles(new Vector3(-90f, -90.0f, 0.0f)));
                    break;
                }
            default:
                {
                    break;
                }
        }
    }
    
    void HandleItemChoice(object sender, DialogueArgs dialog)
    {
        string choice = dialog.dialgogueSelected;

        PawnShopItemDialogue.ChoicesCanvas.gameObject.SetActive(false);
        PawnShopItemDialogue.DiagBox.gameObject.SetActive(true);



        ItemSystem itSys = ItemSystem.instance;

        string reply = "What? (invalid answer, bug programmer";
        InventoryItem item = itSys.GetItem("evidence");

        switch (choice)
        {
            case "How much is it worth?":
                {
                    switch (item.Name)
                    {
                        case "Rolex":
                            {
                                reply = "It's a small Rolex worth, fit for a lil' girl. I'd say $145.";
                                break;
                            }
                        case "Satanic Bible":
                            {
                                reply = "Satanic bibles? I don't think anyone would buy this weird thing.";

                                break;
                            }
                        case "Red Herring":
                            {
                                reply = "Nothing.";
                                break;
                            }
                        default:
                            {
                                reply = "INVALID ANSWER, bug the programmer.";
                                break;
                            }
                    }
                    break;
                }
            case "Who would buy this?":
                {
                    switch (item.Name)
                    {
                        case "Rolex":
                            {
                                reply = "Probably a young girl, somewhere around your age I guess.";
                                break;
                            }
                        case "Satanic Bible":
                            {
                                reply = "Worshippers of Satan? Who else?";

                                break;
                            }
                        case "Red Herring":
                            {
                                reply = "Fisherman, I reckon.";
                                break;
                            }
                        default:
                            {
                                reply = "INVALID ANSWER, bug the programmer.";
                                break;
                            }
                    }
                    break;
                }
            case "Where would someone get this?":
                {
                    switch (item.Name)
                    {
                        case "Rolex":
                            {
                                reply = "Nowhere around here that I can think of. Nearest store 's in Seattle!";
                                break;
                            }
                        case "Satanic Bible":
                            {
                                reply = "Heck if I know.";

                                break;
                            }
                        case "Red Herring":
                            {
                                reply = "The sea?";
                                break;
                            }
                        default:
                            {
                                reply = "INVALID ANSWER, bug the programmer.";
                                break;
                            }
                    }
                    break;
                }
            default:
                {
                    reply = "INVALID ANSWER, bug the programmer!!!";
                    break;
                }
        }

        PawnShopItemDialogue.DiagBox.AssignDialogue(reply);
    }
    void HandleItemDialogue(object sender, DialogueBoxArgs dialog)
    {
        ++progress;
    }

    void DebugDialogue(object sender, DialogueArgs diaArgs)
    {
        Debug.Log(diaArgs.dialgogueSelected);
    }
}
