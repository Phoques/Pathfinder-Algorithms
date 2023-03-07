using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public List<Waypoint> _neighbours;

    //OnValidate updates things every time the editor / inspector is changed
    private void OnValidate()
    {
        ValidateNeighbours();
    }

    private void ValidateNeighbours()
    {
        foreach (Waypoint waypoint in _neighbours)
        {
            if (waypoint == null) 
                continue;

            if (!waypoint._neighbours.Contains(this)) 
            {
                waypoint._neighbours.Add(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        foreach (Waypoint neighbour in _neighbours)
        {
            if (neighbour == null) continue;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, neighbour.transform.position);
        }
    }

}
