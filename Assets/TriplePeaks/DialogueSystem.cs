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

    void Awake()
    {

    }

	// Use this for initialization
	void Start () {
	
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
}
