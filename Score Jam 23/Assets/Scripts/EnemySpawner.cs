using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    float randomTimeModifier = 1f;

    [SerializeField]
    float timeBetweenCamSpawns = 6f;

    [SerializeField]
    float timeBetweenDroidSpawns = 8f;

    [SerializeField]
    float timeBetweenWatcherSpawns = 10f;

    [SerializeField]
    GameObject camEnemy;

    [SerializeField]
    GameObject droidEnemy;

    [SerializeField]
    float droidMaxHeightSpawn = 4f;

    [SerializeField]
    float droidMinHeightSpawn = -1.5f;

    [SerializeField]
    GameObject watcherEnemy;

    private float timeNextCam;
    private float timeNextDroid;
    private float timeNextWatcher;

    private float camTimeElapsed = 0f;
    private float droidTimeElapsed = 0f;
    private float watcherTimeElapsed = 0f;
    private Vector3 spawnPoint;

    private void Start()
    {
        spawnPoint = transform.position;
        timeNextCam = timeBetweenCamSpawns + randomTimeModifier;
        timeNextDroid = timeBetweenDroidSpawns + randomTimeModifier;
        timeNextWatcher = timeBetweenWatcherSpawns + randomTimeModifier;
    }

    private void Update()
    {
        camTimeElapsed += Time.deltaTime;
        droidTimeElapsed += Time.deltaTime;
        watcherTimeElapsed += Time.deltaTime;

        //cam
        if (camTimeElapsed >= timeNextCam)
        {
            camTimeElapsed = 0f;

            SpawnEnemy(camEnemy, spawnPoint);
            GenerateNewTime(ref timeNextCam);
        }
        //droid
        if (droidTimeElapsed >= timeNextDroid)
        {
            droidTimeElapsed = 0f;

            float randomY = Random.Range(droidMinHeightSpawn, droidMaxHeightSpawn);
            Debug.Log(randomY);
            Vector3 droidSpawnPoint = new Vector3(spawnPoint.x, randomY, 0f);

            SpawnEnemy(droidEnemy, droidSpawnPoint);
            GenerateNewTime(ref timeNextDroid);
        }
        //watcher
        if (watcherTimeElapsed >= timeNextWatcher)
        {
            watcherTimeElapsed = 0f;

            SpawnEnemy(watcherEnemy, spawnPoint);
            GenerateNewTime(ref timeNextWatcher);
        }
    }

    private void SpawnEnemy(GameObject enemy, Vector3 location)
    {
        Instantiate(enemy, location, Quaternion.identity);
    }    

    private void GenerateNewTime(ref float timeVar)
    {
        float randTime = Random.Range(0f, randomTimeModifier);
        timeVar = randTime + timeBetweenCamSpawns;
    }
}
