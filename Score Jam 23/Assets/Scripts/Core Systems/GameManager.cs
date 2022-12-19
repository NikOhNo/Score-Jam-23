using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    CanvasGroup gameOverCanvas;

    [SerializeField]
    float gameOverFadeInTime = 1f;

    void Start()
    {
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if (!response.success)
            {
                Debug.Log("error starting LootLocker session");

                return;
            }

            Debug.Log("successfully started LootLocker session");
        });
    }

    IEnumerator DisplayMessage(CanvasGroup messageCanvasGroup, float fadeInTime)
    {
        float timeElapsed = 0f;

        // Fade In
        while (timeElapsed < fadeInTime)
        {
            timeElapsed += Time.deltaTime;

            messageCanvasGroup.alpha = timeElapsed / fadeInTime;

            yield return null;
        }
        messageCanvasGroup.alpha = 1f;
        gameOverCanvas.interactable = true;
    }

    public IEnumerator GameOver()
    {
        Time.timeScale = 0.75f;

        yield return new WaitForSeconds(0.05f); // Fixes camera shake bug
        ScreenShaker.instance.ShakeCamera(2f, 5f, 3f);


        FindObjectOfType<PlayerShooting>().enabled = false;
        FindObjectOfType<PlayerMovement>().enabled = false;

        FindObjectOfType<EnemySpawner>().enabled = false;
        FindObjectOfType<PlatformSpawner>().enabled = false;
        FindObjectOfType<PowerUpSpawner>().enabled = false;
        
        Rigidbody2D[] allRbs = FindObjectsOfType<Rigidbody2D>();
        foreach (Rigidbody2D rb in allRbs)
        {
            rb.freezeRotation = true;
            rb.velocity = Vector2.zero;
            rb.angularVelocity = 0f;
            rb.isKinematic = true;
            rb.Sleep();
        }

        ScrollMover[] scrollMovers = FindObjectsOfType<ScrollMover>();
        foreach (ScrollMover sm in scrollMovers)
        {
            sm.enabled = false;
        }

        EnemyMovement[] enemyMovers = FindObjectsOfType<EnemyMovement>();
        foreach (EnemyMovement em in enemyMovers)
        {
            em.enabled = false;
        }

        EnemyCrawlMovement[] enemyCrawlers = FindObjectsOfType<EnemyCrawlMovement>();
        foreach (EnemyCrawlMovement ecm in enemyCrawlers)
        {
            ecm.enabled = false;
        }

        yield return new WaitForSeconds(4f);

        StartCoroutine(DisplayMessage(gameOverCanvas, gameOverFadeInTime));

        Health[] enemies = FindObjectsOfType<Health>();
        foreach (Health e in enemies)
        {
            e.Die();
        }

        // Get and Upload Score
        // Display lose effects and retry graphic
    }
}
