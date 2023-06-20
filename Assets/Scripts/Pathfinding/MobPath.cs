using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MobPath : AStar

{
    public Vector3 _endGoal;
    public Vector3 _startGoal;
    private float speed = 0.5f;
    private int currentIndex = 0;

    //SpawnEnemies spawnEnemiesClass;

    void Update()
    {
        MoveToObjective();
    }


    private void Start()
    {
        //spawnEnemiesClass = FindObjectOfType<SpawnEnemies>();
    }


    public void MoveToObjective()
    {
       

        List<Node> path = FindShortestPath(StartNode, EndNode); // dont recalculate every frame, consider it running when the tower is placed.

       // _endGoal = path[path.Count-1].transform.position;//EndNode.transform.position;
       // _startGoal = path[0].transform.position;//StartNode.transform.position;

        if(path.Count <= 1 )
        {
            //MADE IT TO THE END
            return;
        }

        //Update start node
        if (Vector3.Distance(transform.position, path[1].transform.position) < 0.2f)
        {
            StartNode = path[1];
            //index++;
        }

        //use path[index] until your at the end(Updating index ++ when you reach the next node), then you only have to find Shortest Path() once.


        transform.position = Vector3.MoveTowards(transform.position, path[1].transform.position, speed * Time.deltaTime);
  /*      if (Vector3.Distance(transform.position, path[1].transform.position) < 0.3f)
        {
            currentIndex++; //todo: dont go above path.count
        }*/


        for (int index = 0; index < path.Count - 1; index++)
        {



            //Need to figure out how to assign the 'next node' in the line for the enemy unit to follow.

            Debug.DrawLine(path[index].transform.position + Vector3.up, path[index + 1].transform.position + Vector3.up,
                Color.black, 0.1f);

            
        }



        Debug.Log("Enemy Should Move");
       
    }
 
}
