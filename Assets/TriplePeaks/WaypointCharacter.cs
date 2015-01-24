using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class WaypointArgs : EventArgs
{
    public WaypointArgs(STATUS stat, Vector3 waypoint)
    {
        NewStatus = stat;
        Waypoint = waypoint;
    }

    public enum STATUS
    {
        STARTING,
        COMPLETED
    }

    STATUS NewStatus;
    Vector3 Waypoint;

}

public class WaypointCharacter : MonoBehaviour {

    public float Speed = 1.0f;
    public List<Vector3> Waypoints;

    public bool ShouldMove;

    public delegate void WaypointStatusChanged(object sender, WaypointArgs args);
    public event WaypointStatusChanged WaypointChanged;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        MoveToWaypoint();
	}

    void MoveToWaypoint()
    {
        if (!ShouldMove)
            return;

        if (Waypoints.Count > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, Waypoints[0], Speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, Waypoints[0]) < 0.1f)
            {
                if (WaypointChanged != null)
                {
                    WaypointChanged(this, new WaypointArgs(WaypointArgs.STATUS.COMPLETED, Waypoints[0]));
                }

                Waypoints.RemoveAt(0);

                if (WaypointChanged != null)
                {
                    WaypointChanged(this, new WaypointArgs(WaypointArgs.STATUS.STARTING, Waypoints[0]));
                }
            }
        }
    }


}
