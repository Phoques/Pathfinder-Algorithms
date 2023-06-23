using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    //field
    private float _pathWeight = int.MaxValue;

    //property
    public float pathWeight
    {
        get { return _pathWeight; }
        set { _pathWeight = value; }
    }
    public float distanceToEnd;

    //this adds weight to nodes. use this example to add a 'threat weight' or something to weigh up a turret being placed.
    //Make sure to have whenever something is placed, re-run the algorithm.
    //create loops for a 10 x 10 grid? (x and y)
    // generate nodes on y axis by 10, then one on the x axis, then gen 10 on the y etc.
    //connect to neighbours (You can just manually assign nodes, which is easier.)
    public float PathWeightDistance
    {
        get { return _pathWeight + distanceToEnd; }

    }

    private Vector3 _endPosition;



    public Node PreviousNode { get; set; }


    [SerializeField] public List<Node> neighbours;

    public void ResetNode(Vector3 endPosition)
    {
        _pathWeight = int.MaxValue;
        PreviousNode = null;
        _endPosition = endPosition;
        distanceToEnd = Vector3.Distance(transform.position, _endPosition);
    }


    //OnValidate updates things every time the editor / inspector is changed
    private void OnValidate()
    {
        ValidateNeighbours();
    }

    private void ValidateNeighbours()
    {
        foreach (Node waypoint in neighbours)
        {
            if (waypoint == null)
                continue;

            if (!waypoint.neighbours.Contains(this))
            {
                waypoint.neighbours.Add(this);
            }
        }
    }

    private void OnDrawGizmos()
    {
        foreach (Node neighbour in neighbours)
        {
            if (neighbour == null) continue;
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, neighbour.transform.position);
        }
    }



}
