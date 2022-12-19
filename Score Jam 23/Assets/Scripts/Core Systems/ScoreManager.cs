using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    float secondScoreValue = 10;

    int finalScore = 0;
    float currScoreFloat = 0f;
    int currScoreInt = 0;
    bool gameOver = false;

    private void Update()
    {
        // add score for survive time if game not over
        if(!gameOver)
        {
            currScoreFloat += secondScoreValue * Time.deltaTime;
            currScoreInt = Mathf.FloorToInt(currScoreFloat);

            // update score display
            UpdateScoreText(currScoreInt);
        }
    }

    private void UpdateScoreText(int amount)
    {
        ScoreDisplay[] scoreTexts = FindObjectsOfType<ScoreDisplay>();
        foreach (ScoreDisplay sT in scoreTexts)
        {
            sT.UpdateScore(amount);
        }
    }

    public void FinalizeScore()
    {
        gameOver = true;
        finalScore = Mathf.FloorToInt(currScoreFloat);
        UpdateScoreText(finalScore);
    }

    public void AddScore(int amount)
    {
        currScoreFloat += amount;
    }

    public void SubtractScore(int amount)
    {
        currScoreFloat -= amount;
    }

    public void ResetScore()
    {
        currScoreInt = 0;
        currScoreFloat = 0f;
        finalScore = 0;
    }

    public void SubmitScore()
    {
        string memberID = "20";
        string leaderboardKey = "player_leaderboard";

        LootLockerSDKManager.SubmitScore(memberID, finalScore, leaderboardKey, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("Successful");
            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });
    }

    public void GetScoreList()
    {
        string leaderboardKey = "player_leaderboard";
        int count = 50;

        LootLockerSDKManager.GetScoreList(leaderboardKey, count, 0, (response) =>
        {
            if (response.statusCode == 200)
            {
                Debug.Log("Successful");
            }
            else
            {
                Debug.Log("failed: " + response.Error);
            }
        });
    }
}
