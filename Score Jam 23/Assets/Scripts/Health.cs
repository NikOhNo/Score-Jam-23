using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int maxHealth;

    [SerializeField]
    public int currHealth;

    void Start()
    {
        currHealth = maxHealth;
    }

    public void SetMaxHealth(int amount)
    {
        maxHealth = amount;
    }

    public void DecreaseHealth()
    {
        currHealth--;

        if (currHealth <= 0)
        {
            Die();
        }
    }

    public void IncreaseHealth()
    {
        if (currHealth + 1 <= maxHealth)
        {
            currHealth++;
        }
    }

    public virtual void Die()
    {

    }
}
