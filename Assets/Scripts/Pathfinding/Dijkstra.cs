using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

using Debug = UnityEngine.Debug;

public class Dijkstra : MonoBehaviour
{

    public Node StartNode;
    public Node EndNode;

    protected Node[] _nodesInScene;

    
    public void RunXTimes(int x)
    {
        GetAllNodes();
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();
        for( int loop = 0; loop < x; loop++)
        {
            RunAlgorithm(StartNode, EndNode);
        }
        stopwatch.Stop();
        
        LogMessage(stopwatch.Elapsed.TotalMilliseconds.ToString());
    }

    public virtual void LogMessage(string text)
    {
        Debug.LogWarning("Dijkstra: " + text);
    }

    public void GetAllNodes()
    {
        _nodesInScene = FindObjectsOfType<Node>();
    }

    protected void Start()
    {
        //RunAndDisplayPath();
        RunXTimes(1000);
    }

    protected void RunAndDisplayPath()
    {
        List<Node> path = FindShortestPath(StartNode, EndNode);



        for (int index = 0; index < path.Count - 1; index++)
        {
            
            Debug.DrawLine(path[index].transform.position + Vector3.up, path[index + 1].transform.position + Vector3.up,
                Color.red, 10f);

            Debug.Log(path[index].gameObject.name);
        }
        Debug.Log(path[path.Count - 1].gameObject.name);
    }


    public List<Node> FindShortestPath(Node start, Node end)
    {
        GetAllNodes();

        if(RunAlgorithm(start, end))
        {
            List<Node> results = new List<Node>();
            Node currentNode = end;

            do
            {
                results.Insert(0, currentNode);
                currentNode = currentNode.PreviousNode;
            } while (currentNode != null);

            return results;
        }

        return null;
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
            unexplored.Sort((x,y) => x.pathWeight.CompareTo(y.pathWeight));

            //This is the current node
            Node current = unexplored[0];

            //Once here we remove the node from the list as its explored.
            unexplored.RemoveAt(0);

            

            foreach (Node neighbourNode in current.neighbours)
            {
                if (!unexplored.Contains(neighbourNode)) continue;

                float neighbourWeight = Vector3.Distance(neighbourNode.transform.position, current.transform.position);

                neighbourWeight += current.pathWeight;

                if(neighbourWeight < neighbourNode.pathWeight)
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














