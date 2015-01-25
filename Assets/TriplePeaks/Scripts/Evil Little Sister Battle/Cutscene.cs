using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using System;

public class Cutscene : MonoBehaviour 
{

	private List<string> _cutsceneDialogue = new List<string>();	//	Things that are gonna be said yo.

	public bool Finished {get; private set;}
	public int SecondsForEachDialogue = 4;
	public Text _CurrentDialogue;

	private TimeSpan _delayBetweenDialogues;
	private DateTime _whenLastDialogueDisplayed;
	private DateTime _now;
	private DateTime _whenToFinish;
	private bool _ending = false;
	private int _dialogueIterator = 0;


	// Use this for initialization
	void Start () 
	{
		_whenLastDialogueDisplayed = DateTime.Now;
		_delayBetweenDialogues = new TimeSpan(0,0, SecondsForEachDialogue);
		_now = DateTime.Now;
		_whenToFinish = new DateTime();

		Finished = false;

		//Drama!
		_cutsceneDialogue.Add (" Brother! You found me...");
		_cutsceneDialogue.Add (" I knew you would <3");
		_cutsceneDialogue.Add (" Brother I've got a secret to tell you... ");
		_cutsceneDialogue.Add (" My secret is... I - I ... ");
		_cutsceneDialogue.Add (" I love you!");
		_cutsceneDialogue.Add (" ... TO DEATH ... ");
	}
	
	// Update is called once per frame
	void Update () 
	{
		//Run cutscene update loop until it's over.
		if(!Finished)
		{
			_now = DateTime.Now;
			
			if(_now >= _whenLastDialogueDisplayed + _delayBetweenDialogues || Input.GetMouseButtonUp (0))
			{
				_whenLastDialogueDisplayed = _now;
				if(_dialogueIterator != _cutsceneDialogue.Count - 1)
				{
					_dialogueIterator++; //	advance dialogue
				}
			}
			
			//text emphasis
			switch(_dialogueIterator)
			{
				case 4:
				{
					_CurrentDialogue.fontSize = 24;
					_CurrentDialogue.color = Color.magenta;
					break;
				}
				case 5:
				{
					if(!_ending)
					{
						_CurrentDialogue.fontSize = 24;
						_CurrentDialogue.color = Color.red;
						_whenToFinish = _now + _delayBetweenDialogues; // Cut scene will end in X seconds after reaching last dialogue 
						_ending = true;
					}
					break;
				}
				default:
					break;

			}

			//Display current dialogue
			_CurrentDialogue.text = _cutsceneDialogue[_dialogueIterator];

			if(_ending && _now >= _whenToFinish)
			{	
				Finished = true;
			}
		}
		if(Finished)
		{
			_CurrentDialogue.text = "";
		}
	}
}
