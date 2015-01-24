using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryItem
{
    string Name;
    string Description;
}

public class ItemSystem : MonoBehaviour {

    public int Lives = 3;

    private static ItemSystem _instance;

    public static ItemSystem instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<ItemSystem>();
            }
            return _instance;
        }
    }

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddItem(string key, InventoryItem item)
    {
        Items.Add(key, item);
    }

    public InventoryItem GetItem(string key)
    {
        return Items[key];
    }

    Dictionary<string, InventoryItem> Items;
}
