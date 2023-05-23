using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{

    public GameObject enemyMob;
    public Transform _enemySpawner;
    public float spawnRate = 1f;
    public float spawnCountDown = 0f;


    private void Start()
    {
        InvokeRepeating("Spawn", 0f, 2f);
    }


    private void Spawn()
    {
        // need to assign the start and end point here and this should fix it.
        Instantiate(enemyMob, _enemySpawner.position, _enemySpawner.rotation);
    }

}
