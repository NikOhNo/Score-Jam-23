using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    float timeBetweenSpawns = 6f;

    [SerializeField]
    float randomTimeModifier = 1f;

    [SerializeField]
    GameObject camEnemy;

    private float currTimeForEnemy;
    private float timeElapsed = 0f;
    private Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
        currTimeForEnemy = timeBetweenSpawns + randomTimeModifier;
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= currTimeForEnemy)
        {
            timeElapsed = 0f;

            SpawnEnemy(camEnemy);
        }
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, spawnPoint, Quaternion.identity);
    }    

    private void GenerateNewTime()
    {
        float randTime = Random.Range(0f, randomTimeModifier);
        currTimeForEnemy = randTime + timeBetweenSpawns;
    }
}
