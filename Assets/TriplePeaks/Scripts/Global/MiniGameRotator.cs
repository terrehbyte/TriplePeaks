using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MiniGameRotator : MonoBehaviour {

    [SerializeField]
    private List<GameObject> Minigames = new List<GameObject>();
    private int CurrentIndex = 0;

    void Start()
    {
        Minigames[0].SetActive(true);
    }

	public bool NextMinigame()
    {
        Minigames[CurrentIndex].SetActive(false);
        
        CurrentIndex++;

        if (CurrentIndex > Minigames.Count)
        {
            return false;
        }

        Minigames[CurrentIndex].SetActive(true);

        return true;
    }
}
