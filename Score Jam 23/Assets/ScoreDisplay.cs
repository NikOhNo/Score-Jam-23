using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    private TMP_Text myText;

    private void Awake()
    {
        myText = GetComponent<TMP_Text>();
    }

    public void UpdateScore(int amount)
    {
        myText.text = amount.ToString();
    }
}
