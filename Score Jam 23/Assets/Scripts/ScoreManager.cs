using LootLocker.Requests;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    int currScore = 0;

    public void AddScore(int amount)
    {
        currScore += amount;
    }

    public void SubtractScore(int amount)
    {
        currScore -= amount;
    }

    public void ResetScore()
    {
        currScore = 0;
    }

    public void SubmitScore()
    {
        string memberID = "20";
        int leaderboardID = 9659;

        LootLockerSDKManager.SubmitScore(memberID, currScore, leaderboardID, (response) =>
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
