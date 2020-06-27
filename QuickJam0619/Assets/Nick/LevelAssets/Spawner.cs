using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject enemyToSpawn;

    private float spawnRate;

    public Transform[] spawnSpots;

    private float timeBetweenSpawns;
    public float startTimeBetweenSpawns;

    // Start is called before the first frame update
    void Start()
    {
        timeBetweenSpawns = startTimeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenSpawns <= 0)
        {
            Instantiate(enemyToSpawn, spawnSpots[Random.Range(0, spawnSpots.Length - 1)].position, Quaternion.identity);
            timeBetweenSpawns = startTimeBetweenSpawns;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }
}
