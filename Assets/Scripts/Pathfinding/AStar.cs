using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStar : Dijkstra
{

    private void Update()
    {
        RunAndDisplayPath();
    }

    public override void LogMessage(string text)
    {
        Debug.LogWarning("AStar: " + text);
    }

    protected virtual bool RunAlgorithm(Node startWaypoint, Node endWaypoint)
    {
        List<Node> unexplored = new List<Node>();
        Node start = null;
        Node end = null;

        //This is storing the nodes
        foreach (Node obj in _nodesInScene)
        {
            Node node = obj.GetComponent<Node>();
            if (node == null) continue;
            node.ResetNode(endWaypoint.transform.position);
            unexplored.Add(node);

            if (startWaypoint == obj) start = node;
            if (endWaypoint == obj) end = node;
        }



        if (start == null && end == null)
        {
            return false;
        }

        //This is referring to the property we set in the Node Class
        start.pathWeight = 0;

        while (unexplored.Count > 0)
        { // the Sort function requires a comparison.
          // This line says (x,y) is the 'parametres' and => is setting x and y values to Pathweight. (Sorry confused a bit)
            unexplored.Sort((x, y) => x.PathWeightDistance.CompareTo(y.PathWeightDistance));

            //This is the current node
            Node current = unexplored[0];

            //Once here we remove the node from the list as its explored.
            unexplored.RemoveAt(0);



            foreach (Node neighbourNode in current.neighbours)
            {
                if (!unexplored.Contains(neighbourNode)) continue;

                float neighbourWeight = Vector3.Distance(neighbourNode.transform.position, current.transform.position);

                neighbourWeight += current.pathWeight;

                if (neighbourWeight < neighbourNode.pathWeight)
                {
                    neighbourNode.pathWeight = neighbourWeight;
                    neighbourNode.PreviousNode = current;
                }
            }
            if (current == end) break; // We have found the shortest path, stop looping through unexplored.
        }

        return true;

    }
}
