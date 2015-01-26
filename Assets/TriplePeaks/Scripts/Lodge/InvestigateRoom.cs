using UnityEngine;
using System.Collections;

public class InvestigateRoom : MonoBehaviour {

    public GameObject Waypoint1;
    public GameObject Waypoint2;
    public GameObject Waypoint3;

    public Vector3 PickedPosition;

    public bool MadeSelection;

    public bool Item1;
    public bool Item2;
    public bool Item3;

    public float speed = 15.0f;
    
    // Use this for initialization
	void Start () 
    {
        speed = 15.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        PickPlace();
        CheckDistance();
	}

    void PickPlace()
    {
        float step = speed * Time.deltaTime;
        if (!MadeSelection)
        {
            if (Input.GetKeyUp(KeyCode.LeftArrow))
            {
                //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Waypoint3.transform.position, step);
                PickedPosition = Waypoint3.transform.position;
                MadeSelection = true;
                Item3 = true;

                InventoryItem item = new InventoryItem();
                item.Name = "Rolex";

                ItemSystem.instance.AddItem("evidence", item);
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Waypoint1.transform.position, step);
                PickedPosition = Waypoint1.transform.position;
                MadeSelection = true;
                Item1 = true;
                InventoryItem item = new InventoryItem();
                item.Name = "Red Herring";

                ItemSystem.instance.AddItem("evidence", item);
            }

            if (Input.GetKeyUp(KeyCode.RightArrow))
            {
                //gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, Waypoint2.transform.position, step);
                PickedPosition = Waypoint2.transform.position;
                MadeSelection = true;
                Item2 = true;

                InventoryItem item = new InventoryItem();
                item.Name = "Satanic Bible";

                ItemSystem.instance.AddItem("evidence", item);
            }
        }

        if(MadeSelection)
            gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position, PickedPosition, step);
    }

    void CheckDistance()
    {
        if (Vector3.Distance(gameObject.transform.position, PickedPosition) <= 3.2f)
        {
            LevelSystem.instance.LoadNextLevel();
        }
    }
}
