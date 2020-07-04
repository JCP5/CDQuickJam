using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner spawner;
    public GameObject[] enemies;

    public float wave = 1;
    private int numOfEnemies;

    public Transform[] spawnSpots;

    private float timeBetweenSpawns;
    public float startTimeBetweenSpawns = 10;

    // Start is called before the first frame update
    void Start()
    {
        if (spawner == null)
            spawner = this;
        else
            Destroy(this.gameObject);

        timeBetweenSpawns = startTimeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenSpawns <= 0)
        {
            wave++;

            SpawnEnemies();

            timeBetweenSpawns = startTimeBetweenSpawns + wave;
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < wave; i++)
        {
            numOfEnemies++;
            Instantiate(enemies[Random.Range(0, enemies.Length - 1)], spawnSpots[Random.Range(0, spawnSpots.Length - 1)].position, Quaternion.identity);
        }
    }

    public void SubtractNumOfEnemies()
    {
        numOfEnemies--;

        if (numOfEnemies <= 0)
        {
            wave++;

            SpawnEnemies();

            timeBetweenSpawns = startTimeBetweenSpawns + wave;
        }
    }
}
