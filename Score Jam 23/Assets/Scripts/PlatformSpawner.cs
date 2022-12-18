using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField]
    float randomTimeModifier = 1f;

    [SerializeField]
    float maxHeightSpawn = 3f;

    [SerializeField]
    float minHeightSpawn = -1.5f;

    [SerializeField]
    float timeBetweenRegularSpawns = 6f;

    [SerializeField]
    float timeBetweenBreakableSpawns = 8f;

    [SerializeField]
    float timeBetweenMovingSpawns = 10f;

    [SerializeField]
    GameObject regPlatform;

    [SerializeField]
    GameObject breakPlatform;

    [SerializeField]
    GameObject movePlatform;

    private float timeNextReg;
    private float timeNextBreak;
    private float timeNextMove;

    private float regTimeElapsed = 0f;
    private float breakTimeElapsed = 0f;
    private float moveTimeElapsed = 0f;
    private Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
        timeNextReg = timeBetweenRegularSpawns + randomTimeModifier;
        timeNextBreak = timeBetweenBreakableSpawns + randomTimeModifier;
        timeNextMove = timeBetweenMovingSpawns + randomTimeModifier;
    }

    private void Update()
    {
        regTimeElapsed += Time.deltaTime;
        breakTimeElapsed += Time.deltaTime;
        moveTimeElapsed += Time.deltaTime;

        //reg
        if (regTimeElapsed >= timeNextReg)
        {
            regTimeElapsed = 0f;

            Vector3 randomSpawn = GenerateRandomSpawn();
            SpawnEnemy(regPlatform, randomSpawn);
            GenerateNewTime(ref timeNextReg);
        }
        //break
        if (breakTimeElapsed >= timeNextBreak)
        {
            breakTimeElapsed = 0f;

            Vector3 randomSpawn = GenerateRandomSpawn();
            SpawnEnemy(breakPlatform, randomSpawn);
            GenerateNewTime(ref timeNextBreak);
        }
        //moving
        if (moveTimeElapsed >= timeNextMove)
        {
            moveTimeElapsed = 0f;

            Vector3 randomSpawn = GenerateRandomSpawn();
            SpawnEnemy(movePlatform, randomSpawn);
            GenerateNewTime(ref timeNextMove);
        }
    }

    private Vector3 GenerateRandomSpawn()
    {
        float randomY = Random.Range(minHeightSpawn, maxHeightSpawn);
        Vector3 droidSpawnPoint = new Vector3(spawnPoint.x, randomY, 0f);
        return droidSpawnPoint;
    }

    private void SpawnEnemy(GameObject enemy, Vector3 location)
    {
        Instantiate(enemy, location, Quaternion.identity);
    }

    private void GenerateNewTime(ref float timeVar)
    {
        float randTime = Random.Range(0f, randomTimeModifier);
        timeVar = randTime + timeBetweenRegularSpawns;
    }
}
