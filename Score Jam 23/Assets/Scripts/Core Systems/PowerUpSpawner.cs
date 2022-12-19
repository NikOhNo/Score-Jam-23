using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField]
    float timeBetweenSpawns = 7.5f;

    [SerializeField]
    float maxHeightSpawn = 4f;

    [SerializeField]
    float minHeightSpawn = -1.5f;

    [SerializeField]
    GameObject[] powerUps;

    private Vector3 spawnPoint;
    private float timeElapsed = 0f;

    private void Start()
    {
        spawnPoint = transform.position;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeBetweenSpawns)
        {
            float randomY = Random.Range(minHeightSpawn, maxHeightSpawn);
            Vector3 randomSpawn = new Vector3(spawnPoint.x, randomY, 0f);

            GameObject randomPowerUp = powerUps[Random.Range(0, powerUps.Length)];

            SpawnPowerUp(randomPowerUp, randomSpawn);

            timeElapsed = 0f;
        }
    }

    private void SpawnPowerUp(GameObject powerUp, Vector3 location)
    {
        Instantiate(powerUp, location, Quaternion.identity);
    }
}
