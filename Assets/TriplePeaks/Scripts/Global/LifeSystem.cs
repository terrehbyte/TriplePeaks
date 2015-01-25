using UnityEngine;
using System.Collections;


public class LifeSystem : MonoBehaviour, DataSystem {

    public int LivesStartingCount = 3;
    public int Lives;

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
        Lives = LivesStartingCount;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void DataSystem.ResetData()
    {
        Lives = LivesStartingCount;
    }
}
