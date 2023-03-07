using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Dijkstra : MonoBehaviour
{
    private Waypoint[] _nodes;

    private void Awake()
    {
        GetAllNodes();
    }
    public void GetAllNodes()
    {
        _nodes = FindObjectsOfType<Waypoint>();
    }
    private bool DijkstraAlgorithm(Waypoint startWaypoint, Waypoint endWaypoint)
    {
        List<Node> unexplored = new List<Node>();
        Node start = null;
        Node end = null;

        //This is storing the nodes
        foreach (Waypoint obj in _nodes)
        {
            Node node = new Node(obj);
            unexplored.Add(node);
            if (startWaypoint == obj) start = node;
            if (endWaypoint == obj) end = node;
        }



        if (start == null && end == null)
        {
            return false;
        }

        //This is referring to the property we set in the Node Class
        start.Pathweight = 0;

        while (unexplored.Count > 0)
        { // the Sort function requires a comparison.
                            // This line says (x,y) is the 'parametres' and => is setting x and y values to Pathweight. (Sorry confused a bit)
            unexplored.Sort((x,y) => x.Pathweight.CompareTo(y.Pathweight));

            //This is the current node
            Node current = unexplored[0];

            //Once here we remove the node from the list as its explored.
            unexplored.RemoveAt(0);

            if (current == end) break; // We have found the shortest path, stop looping through unexplored.

            /*foreach (Node neighbourNode in current.NeighbourNodes)
            {
                
            }*/

        }

        return true;

    }






}














