using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelSystem : MonoBehaviour
{
    [SerializeField]
    private List<string> levelSequence = new List<string>();

    private static LevelSystem _instance;

    public static LevelSystem instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<LevelSystem>();
            }
            return _instance;
        }
    }

	// Use this for initialization
	void Awake ()
    {
        DontDestroyOnLoad(this);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void LoadPrevLevel()
    {
        int curLevel = levelSequence.FindIndex(x => x == Application.loadedLevelName);

        string nextLevel = levelSequence[curLevel + -1] ?? levelSequence[0]; // @SAM I DID IT

        Application.LoadLevel(nextLevel);
    }

    public void LoadNextLevel()
    {
        int curLevel = levelSequence.FindIndex(x => x == Application.loadedLevelName);

        string nextLevel = (levelSequence.Count -1 >= curLevel+1 ? levelSequence[curLevel+1] : levelSequence[0]); // @SAM I DID IT

        Application.LoadLevel(nextLevel);
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            DataSystem items = ItemSystem.instance as DataSystem;
            DataSystem lives = LifeSystem.instance as DataSystem;

            items.ResetData();
            lives.ResetData();
        }
    }
}
