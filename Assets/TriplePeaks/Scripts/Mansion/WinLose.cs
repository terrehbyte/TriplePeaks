using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WinLose : MonoBehaviour 
{
	public GameObject _Brother;
	public GameObject _Sister;
	public Text _Message;

	public bool GameOver {get;set;}

	// Use this for initialization
	void Start () 
	{
		_Message.text = "";
		GameOver = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if( _Brother.GetComponent<Player>()._Health <= 0)
		{
			_Message.text = "FAILURE. >:( Replay? (Yes you can skip the stupid dialogue :3)";
			_Brother.SetActive(false);
			GameOver = true;
		}
		if( _Sister.GetComponent<EvilSister>()._Health <= 0)
		{
			_Message.text = "CONGRATULATIONS. YOU WIN!";
			_Sister.SetActive (false);
			GameOver = true;
		}

		if(GameOver)
		{
			if(Input.GetMouseButtonUp (0))
			{
                LevelSystem.instance.LoadNextLevel();
			}
		}
	}
}
