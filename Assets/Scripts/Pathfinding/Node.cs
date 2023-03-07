using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    //field
    private float _pathweight = int.MaxValue;

    //property
    public float Pathweight
    {
        get { return _pathweight; }
        set { _pathweight = value; Debug.Log("Hello"); }
    }

    private Waypoint _waypointObj = null;
    public Node(Waypoint waypointObj)
    {
        _waypointObj = waypointObj;
    }


}
