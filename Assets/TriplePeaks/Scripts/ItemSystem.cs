using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InventoryItem
{
    public string Name;
    public string Description;
}

public class ItemSystem : MonoBehaviour {

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

    public bool CheckItemExists(string key)
    {
        return Items.ContainsKey(key);
    }

    Dictionary<string, InventoryItem> Items = new Dictionary<string,InventoryItem>();
}
