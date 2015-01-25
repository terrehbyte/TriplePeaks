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

    public STATUS NewStatus;
    public Vector3 Waypoint;

}

public class WaypointCharacter : MonoBehaviour {

    public float Speed = 1.0f;
    public List<Vector3> Waypoints;

    private bool shouldMove;
    public bool ShouldMove
    {
        get
        {
            return shouldMove;
        }
        set
        {
            shouldMove = value;

            if (value)
            {
                charaAnimator.ResetTrigger("Idle");
                charaAnimator.ResetTrigger("Walking");
                charaAnimator.SetTrigger("Walking");
            }
            else
            {
                charaAnimator.ResetTrigger("Idle");
                charaAnimator.ResetTrigger("Walking");
                charaAnimator.SetTrigger("Idle");
            }
        }
    }

    public Animator charaAnimator;

    public delegate void WaypointStatusChanged(object sender, WaypointArgs args);
    public event WaypointStatusChanged WaypointChanged;

	// Use this for initialization
	void Start () {
        ShouldMove = true;
	
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

                if (WaypointChanged != null && Waypoints.Count > 0 )
                {
                    WaypointChanged(this, new WaypointArgs(WaypointArgs.STATUS.STARTING, Waypoints[0]));
                }
            }
        }
    }
}
