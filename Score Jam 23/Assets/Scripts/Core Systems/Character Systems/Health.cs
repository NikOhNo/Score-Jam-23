using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    int maxHealth;

    [SerializeField]
    int currHealth;

    [SerializeField]
    GameObject deathVFX;

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
        FindObjectOfType<SFXPlayer>().PlayHurtSFX();

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
        FindObjectOfType<SFXPlayer>().PlayExplosionSFX();

        Instantiate(deathVFX, transform.position, Quaternion.identity);

        Destroy(gameObject);
    }
    
    public int GetCurrHealth()
    {
        return currHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }
}
