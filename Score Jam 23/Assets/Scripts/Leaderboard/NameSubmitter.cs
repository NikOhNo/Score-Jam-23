using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NameSubmitter : MonoBehaviour
{
    public Leaderboard leaderboard;
    TMP_InputField myField;

    private void Awake()
    {
        myField = GetComponent<TMP_InputField>();
        myField.characterLimit = 3;
    }

    public void EnforceCharacterLimit()
    {
        if (myField.text.Length > myField.characterLimit - 1)
        {
            myField.text.Substring(0, 3);
        }
    }

    public void SubmitName()
    {
        if (myField.text.Length == myField.characterLimit)
        {
            FindObjectOfType<PlayerManager>().SetPlayerName(myField.text.ToUpper());
        }
    }
}
