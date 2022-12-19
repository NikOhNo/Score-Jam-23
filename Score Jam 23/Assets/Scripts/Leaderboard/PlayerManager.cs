using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;

public class PlayerManager : MonoBehaviour
{
    public Leaderboard leaderboard;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SetupRoutine());
    }

    public void SetPlayerName(string name)
    {
        LootLockerSDKManager.SetPlayerName(name, (response) =>
        {
            if(response.success)
            {
                Debug.Log("Successfully set player name");

                int finalScore = FindObjectOfType<ScoreManager>().GetFinalScore();
                if (finalScore > 0)
                {
                    StartCoroutine(leaderboard.SubmitScoreRoutine(finalScore));
                }
            }
            else
            {
                Debug.Log("Could not set player name" + response.Error);
            }
        });
    }

    IEnumerator SetupRoutine()
    {
        yield return LoginRoutine();
        yield return leaderboard.FetchTopHighscoresRoutine();
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response) =>
        {
            if(response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }
            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });
        yield return new WaitWhile(() => done == false);
    }
}
