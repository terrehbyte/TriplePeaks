using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class room : MonoBehaviour {

	public GameObject twins;
	public Text thing;
	float gameTimer = 0f;





	// Use this for initialization
	void Start () 
	{
		thing.text = "";
	}

	// Update is called once per frame
	void Update () 
	{
		gameTimer += Time.deltaTime;
		MoveTwins ();
		TextManager ();
		//go to hospital scene
	}
	
	void MoveTwins()
	{

		if (gameTimer <= 5f) 
		{
			twins.transform.position += new Vector3 (0, 0, -0.4f) * Time.deltaTime;
			//twins.SetActive(false);
		}
	}

	void TextManager()
	{
		if (gameTimer >= 5) 
		{
			thing.text = "The murderer is very close to you";
			if (gameTimer >= 8) 
			{		
				thing.text = "";
				if (gameTimer >= 9)
				{
					thing.text = "And we know about being close";
					if (gameTimer >= 12)
					{
						thing.text = "";
						if (gameTimer >= 13)
						{
							thing.text = "Thank you! We'll be here till Thursday.";
                            if (gameTimer >= 16)
                            {
                                LevelSystem.instance.LoadNextLevel();
                            }
						}
					}
				}
			}	
		}

	}

	/*void OnGUI()
	{

		{
			laughTimer += Time.deltaTime;
			GUI.TextField (new Rect (600, 170, 27, 20), "Ha");
			GUI.TextField (new Rect (170, 150, 27, 20), "Ha");
			if (laughTimer>=.75f)
			{
			showText2 = false;
			}
		}
	}*/
}
