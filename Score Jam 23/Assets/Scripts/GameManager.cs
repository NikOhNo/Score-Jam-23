using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    CanvasGroup gameOverCanvas;

    [SerializeField]
    float gameOverFadeInTime = 3f;

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
            Debug.Log(timeElapsed);

            messageCanvasGroup.alpha = timeElapsed / fadeInTime;

            yield return null;
        }
        messageCanvasGroup.alpha = 1f;
    }

    public void GameOver()
    {
        ScreenShaker.instance.ShakeCamera(2f, 5f, 4f);
        StartCoroutine(DisplayMessage(gameOverCanvas, gameOverFadeInTime));
        // Get and Upload Score
        // Display lose effects and retry graphic
    }
}
