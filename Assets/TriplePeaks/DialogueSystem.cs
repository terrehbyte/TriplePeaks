using UnityEngine;
using System.Collections;

public class DialogueArgs : System.EventArgs
{
    public DialogueArgs(string dialogue)
    {
        dialgogueSelected = dialogue;
    }

    public string dialgogueSelected;
}

public class DialogueSystem : MonoBehaviour
{
    public delegate void DialogueChosenChanged(object sender, DialogueArgs args);
    public event DialogueChosenChanged DialogueChosen;

    public Canvas ChoicesCanvas;
    public DialogueBox DiagBox;

    void Awake()
    {

    }

	// Use this for initialization
	void Start () {

        DialogueChosen += HandleChoice;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void ReportDialogue(string dialogue)
    {
        if (DialogueChosen != null)
        {
            DialogueChosen( this,new DialogueArgs(dialogue));
        }
    }

    void HandleChoice(object sender, DialogueArgs dialog)
    {
        string choice = dialog.dialgogueSelected;

        ChoicesCanvas.gameObject.SetActive(false);
        DiagBox.gameObject.SetActive(true);

        switch (choice)
        {
            case "How are you?":
                {
                    DiagBox.AssignDialogue("fuck you 1");
                    break;
                }
            case "How is the weather?":
                {
                    DiagBox.AssignDialogue("fuck you 2");
                    break;
                }
            case "Comfort myself.":
                {
                    DiagBox.AssignDialogue("*comforts*");
                    break;
                }
            default:
                {
                    DiagBox.AssignDialogue("ERR NO CHOICE");
                    break;
                }
        }

    }
}
