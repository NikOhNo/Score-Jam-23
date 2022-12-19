using LootLocker.Requests;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectHandler : MonoBehaviour
{
    [SerializeField]
    BoxCollider2D punchHitBox;

    [SerializeField]
    float slowStrength = 0.75f;

    float jumpTimeLeft = 0f;
    float shootTimeLeft = 0f;
    float slowTimeLeft = 0f;
    float punchTimeLeft = 0f;

    bool gameSlowed = false;

    private void Update()
    {
        jumpTimeLeft -= Time.deltaTime;
        shootTimeLeft -= Time.deltaTime;
        slowTimeLeft -= Time.deltaTime;
        punchTimeLeft -= Time.deltaTime;

        if (punchTimeLeft <= 0)
        {
            DeactivatePunching();
        }
        if (slowTimeLeft <= 0f && gameSlowed)
        {
            Time.timeScale = 1f;
            gameSlowed = false;
        }
    }

    public bool JumpBoostActive()
    {
        return jumpTimeLeft > 0f;
    }

    public bool ShootBoostActive()
    {
        return shootTimeLeft > 0f;
    }

    public bool SlowBoostActive()
    {
        return slowTimeLeft > 0f;
    }

    public bool PunchBoostActive()
    {
        return punchTimeLeft > 0f;
    }

    private void ActivatePunching()
    {
        GetComponentInParent<Animator>().SetBool("Punch", true);

        // activate punch hitbox
        punchHitBox.enabled = true;
    }

    private void DeactivatePunching()
    {
        GetComponentInParent<Animator>().SetBool("Punch", false);

        // deactive punch hitbox
        punchHitBox.enabled = false;
    }

    public void SetJumpBoostTime(float time)
    {
        jumpTimeLeft = time;
    }

    public void SetShootTime(float time)
    {
        shootTimeLeft = time;
    }

    public void SetSlowTimeLeft(float time)
    {
        slowTimeLeft = time;

        Time.timeScale = slowStrength;
        gameSlowed = true;
    }

    public void SetPunchTime(float time)
    {
        ActivatePunching();

        punchTimeLeft = time;
    }
}
