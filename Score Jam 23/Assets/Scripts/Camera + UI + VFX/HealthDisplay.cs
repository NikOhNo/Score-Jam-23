using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour
{
    [SerializeField]
    Sprite healthySprite;

    [SerializeField]
    Sprite hurtSprite;

    [SerializeField]
    Image[] heartIcons;

    public void UpdateIcons()
    {
        foreach (Image i in heartIcons)
        {
            i.sprite = healthySprite;
        }

        PlayerHealth playerHealth = FindObjectOfType<PlayerHealth>();
        int currHealth = playerHealth.GetCurrHealth();
        int maxHealth = playerHealth.GetMaxHealth();

        for (int i = 0; i < (maxHealth - currHealth); i++)
        {
            heartIcons[i].sprite = hurtSprite;
        }
    }
}
