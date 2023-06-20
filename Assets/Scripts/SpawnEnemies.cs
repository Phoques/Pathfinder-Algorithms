using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public MobPath enemyMobPrefab;
    public Transform _enemySpawner;
    public float spawnRate = 1f;
    public float spawnCountDown = 0f;

    public Node StartNode;
    public Node EndNode;


    // private Dijkstra dijkstraClass;
    //  private AStar AStarClass;


    private void Start()
    {
        //dijkstraClass = FindObjectOfType<Dijkstra>();
        InvokeRepeating("Spawn", 0f, 2f);
    }


    private void Spawn()
    {
        // need to assign the start and end point here and this should fix it.
      
        MobPath mobPathInstance =  Instantiate(enemyMobPrefab, _enemySpawner.position, _enemySpawner.rotation);
        mobPathInstance.EndNode = EndNode;
        mobPathInstance.StartNode = StartNode;


    }

}
