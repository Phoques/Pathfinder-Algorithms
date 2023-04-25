using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MobPath : Dijkstra

{
    public Vector3 _endGoal;
    public Vector3 _startGoal;
    private float speed = 1f;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveToObjective();
    }


    public void MoveToObjective()
    {
        List<Node> path = FindShortestPath(StartNode, EndNode);

        _endGoal = EndNode.transform.position;
        _startGoal = StartNode.transform.position;

        for (int index = 0; index < path.Count - 1; index++)
        {
            transform.position = Vector3.MoveTowards(transform.position, _endGoal, speed);



            //Need to figure out how to assign the 'next node' in the line for the enemy unit to follow.

            Debug.DrawLine(path[index].transform.position + Vector3.up, path[index + 1].transform.position + Vector3.up,
                Color.black, 0.1f);

            
        }
        Debug.Log("Enemy Should Move");
       
    }
 
}
