using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    private float timeBetweenSpawns;
    public float initialTimeBetweenSpawns;
    public float timeDecrease;
    public float minTime;

    public GameObject[] obstaclesPrefabs;

    private void Start()
    {
        timeBetweenSpawns = initialTimeBetweenSpawns;
    }

    private void Update()
    {
        if (timeBetweenSpawns <= 0)
        {
            int rand = Random.Range(0, obstaclesPrefabs.Length);
            Instantiate(obstaclesPrefabs[rand], transform.position, Quaternion.identity);
            timeBetweenSpawns = initialTimeBetweenSpawns;
            if (initialTimeBetweenSpawns > minTime)
            {
                initialTimeBetweenSpawns -= timeDecrease;
            }
        }
        else
        {
            timeBetweenSpawns -= Time.deltaTime;
        }
    }

}
