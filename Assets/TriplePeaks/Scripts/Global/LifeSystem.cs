using UnityEngine;
using System.Collections;


public class LifeSystem : MonoBehaviour {

    public int Lives = 3;

    private static LifeSystem _instance;

    public static LifeSystem instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<LifeSystem>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
