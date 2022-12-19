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
        ScreenShaker.instance.ShakeCamera(2f, 5f, 4f);

        yield return new WaitForSeconds(4f);

        StartCoroutine(DisplayMessage(gameOverCanvas, gameOverFadeInTime));
        // Get and Upload Score
        // Display lose effects and retry graphic
    }
}
