using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public static Spawner instance;
    public GameObject[] enemies;

    public float wave = 1;
    private int numOfEnemies;

    public Transform[] spawnSpots;

    public float timeBetweenSpawns;
    public float startTimeBetweenSpawns = 10;

    // Start is called before the first frame update
    void Start()
    {
        InitializeSpawner();

        SpawnEnemies();

        timeBetweenSpawns = startTimeBetweenSpawns;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBetweenSpawns <= 0)
        {
            timeBetweenSpawns = startTimeBetweenSpawns + wave;

            AddWave();

            SpawnEnemies();
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
            AddWave();

            SpawnEnemies();

            timeBetweenSpawns = startTimeBetweenSpawns + wave;
        }
    }

    public void InitializeSpawner()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    void AddWave()
    {
        wave++;
        WaveDisplay.instance.SetWave((int)wave);
    }
}
