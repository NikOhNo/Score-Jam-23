using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{
    [SerializeField]
    float invincibleTime = 2.5f;

    bool invincible = false;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Enemy" && !invincible)
        {
            DecreaseHealth();
            ScreenShaker.instance.ShakeCamera(1f, 10f, 0.5f);
            Destroy(collision.gameObject);
            StartCoroutine(InvincibilityTime(invincibleTime));
        }
    }

    IEnumerator InvincibilityTime(float time)
    {
        // May want to add indicator showing invincibility

        invincible = true;
        yield return new WaitForSeconds(time);
        invincible = false;
    }

    public override void Die()
    {
        FindObjectOfType<GameManager>().GameOver();
        // Update remaining health graphic
        // Animation
        GetComponent<Animator>().SetBool("Shoot", false);
        GetComponent<Animator>().SetBool("Punch", false);
        GetComponent<Animator>().SetBool("Dead", true);
    }

    public void DeactivateSelf()
    {
        gameObject.SetActive(false);
    }
}
