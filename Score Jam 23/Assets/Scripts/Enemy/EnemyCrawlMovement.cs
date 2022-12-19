using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;

public class EnemyCrawlMovement : MonoBehaviour
{
    [SerializeField]
    float moveSpeed = -0.25f;

    [SerializeField]
    float crawlTime = 1f;

    [SerializeField]
    float pauseTime = 0.5f;

    private Rigidbody2D myRb;

    bool crawling = true;
    bool paused = false;

    float crawlTimeElapsed = 0f;
    float pauseTimeElapsed = 0f;

    private void Awake()
    {
        myRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (crawling)
        {
            myRb.velocity = new Vector2(moveSpeed, 0f);
            crawlTimeElapsed += Time.deltaTime;
        }
        if(crawling && (crawlTimeElapsed >= crawlTime))
        {
            crawlTimeElapsed = 0f;
            crawling = false;
            paused = true;
        }
        if (paused)
        {
            pauseTimeElapsed += Time.deltaTime;
            myRb.velocity = Vector2.zero;
        }
        if (paused && (pauseTimeElapsed >= pauseTime))
        {
            pauseTimeElapsed = 0f;
            crawling = true;
            paused = false;
        }
    }
}
