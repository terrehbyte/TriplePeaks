using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogueBoxArgs : System.EventArgs
{
    public DialogueBoxArgs(bool confirmed)
    {
        if (confirmed)
        {
            Confirmed = true;
            Cancelled = false;
        }
        else
        {
            Confirmed = false;
            Cancelled = true;
        }
    }

    public bool Confirmed;
    public bool Cancelled;
}

public class DialogueBox : MonoBehaviour {

    public Text MessageText;

    public delegate void DialogueBoxAction(object sender, DialogueBoxArgs boxArgs);
    public event DialogueBoxAction DialogueInteracted;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AssignDialogue(string dialogue)
    {
        MessageText.text = dialogue;
    }

    public void ConfirmMessage(bool messageConfirmed)
    {
        gameObject.SetActive(false);

        if (DialogueInteracted != null)
        {
            DialogueInteracted(this, new DialogueBoxArgs(messageConfirmed));
        }
    }
}
