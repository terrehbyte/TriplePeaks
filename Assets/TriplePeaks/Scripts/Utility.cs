using UnityEngine;
using System.Collections;

public class Utility : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadLevel(string levelName)
    {
        Application.LoadLevel(levelName);
    }

    public void LoadTransition(System.TimeSpan waitTime, string levelName)
    {
        Application.LoadLevel("Transition");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
